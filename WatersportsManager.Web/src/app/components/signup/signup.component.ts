import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgToastService } from 'ng-angular-popup';
import ValidateForm from 'src/app/helpers/validateform';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss'],
})
export class SignupComponent {

  type: string = "password"
  isText: boolean = false;
  eyeIcon: string = "visibility"
  signUpForm!: FormGroup;
  constructor(
    private fb: FormBuilder,
    private auth: AuthService, private router: Router,
    private toast: NgToastService) { }

  ngOnInit(): void {
    this.signUpForm = this.fb.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      username: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required]
    })
  }

  hideShowPass() {
    this.isText = !this.isText;
    this.isText ? this.eyeIcon = "visibility_off" : this.eyeIcon = "visibility"
    this.isText ? this.type = "text" : this.type = "password"
  }

  onSignup() {
    if (this.signUpForm.valid) {
      // Perform logic for signup
      this.auth.signUp(this.signUpForm.value).then((res: any) => {
        this.signUpForm.reset();
        this.toast.success({ detail: "SUCCESS", summary: res.message, duration: 5000 });
        this.router.navigate(['login']);
      }).catch((error: any) => {
        this.toast.error({ detail: "ERROR", summary: error.error.message, duration: 5000 });
      });
    } else {
      // Throw the error using toaster with required fields
      ValidateForm.validateAllFormFields(this.signUpForm);
      this.toast.error({ detail: "ERROR", summary: "Your form is invalid!", duration: 5000 });
    }
  }
}
