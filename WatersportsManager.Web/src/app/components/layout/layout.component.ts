import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.scss']
})
export class LayoutComponent implements OnInit {

  fullName: string = "";
  role: string = "";

  constructor(
    private authService: AuthService,
  ) { }

  ngOnInit() {
    this.fullName = this.authService.getFullNameFromToken();
    this.role = this.authService.getRoleFromToken();
  }


  logOut() {
    this.authService.signOut();
  }

}