import { Component, Input } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-topbar',
  templateUrl: './topbar.component.html',
  styleUrls: ['./topbar.component.scss']
})
export class TopbarComponent {

  @Input() role: string = "";
  @Input() fullName: string = "";

  constructor(
    private authService: AuthService,
  ) { }

  logOut() {
    this.authService.signOut();
  }
}