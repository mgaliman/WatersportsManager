import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';
import { PersonStoreService } from 'src/app/services/person-store.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent {

  type: string = "password"
  isText: boolean = false;
  eyeIcon: string = "visibility"
  loginForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private auth: AuthService,
    private router: Router,
    private toast: NgToastService,
    private personStore: PersonStoreService
  ) { }

  ngOnInit(): void {
    this.loginForm = this.fb.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "visibility_off" : this.eyeIcon = "visibility"
    this.isText ? this.type = "text" : this.type = "password"
  }

  onLogin() {
    if (this.loginForm.valid) {

      // Send the object to database
      this.auth.login(this.loginForm.value).then((res: any) => {

        this.loginForm.reset();
        this.auth.storeToken(res.token);
        const tokenPayload = this.auth.decodedToken();
        this.personStore.setFullNameForStore(tokenPayload.unique_name);
        this.personStore.setRoleForStore(tokenPayload.role);
        this.toast.success({ detail: "SUCCESS", summary: res.message, duration: 5000 });
        this.router.navigate(['/home']);

      }).catch((err: any) => {

        this.toast.error({ detail: "ERROR", summary: err.error.message, duration: 5000 });

      });

    } else {

      // Throw the error using toaster with required fields
      ValidateForm.validateAllFormFields(this.loginForm);
      this.toast.error({ detail: "ERROR", summary: "Your form is invalid!", duration: 5000 });

    }
  }
}
