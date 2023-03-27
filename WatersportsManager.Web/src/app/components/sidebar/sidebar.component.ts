import { Component, Input, OnDestroy, OnInit } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit, OnDestroy {

  @Input() role: string = "";
  @Input() fullName: string = "";

  menuItems: any[] = [];

  subsctiptions: any[] = [];

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit(): void {

    this.setMenuItems();

    this.subsctiptions.push(this.router.events.subscribe(({ routerEvent }: any) => {

      if (routerEvent instanceof NavigationEnd) {

        this.menuItems.forEach(m => {

          if (routerEvent.urlAfterRedirects === `/${m.link}`) {
            m.active = true;
          } else {
            m.active = false;
          }

        });
      }

    }));

  }

  ngOnDestroy(): void {
    this.subsctiptions.forEach(s => s.unsubscribe());
  }

  setMenuItems() {
    this.menuItems = [
      {
        link: 'home',
        icon: 'home',
        title: 'Home',
        active: false,
        onlyDisplayFor: undefined
      },
      {
        link: 'people',
        icon: 'groups',
        title: 'People',
        active: false,
        onlyDisplayFor: 'ADMIN'
      },
      {
        link: 'boat-types',
        icon: 'sailing',
        title: 'Boat Types',
        active: false,
        onlyDisplayFor: 'ADMIN'
      },
      {
        link: 'map',
        icon: 'location_on',
        title: 'Map',
        active: false,
        onlyDisplayFor: undefined
      },
      {
        link: 'reservations',
        icon: 'menu_book',
        title: 'Reservations',
        active: false,
        onlyDisplayFor: 'ADMIN'
      },
      {
        link: 'reports',
        icon: 'report',
        title: 'Reports',
        active: false,
        onlyDisplayFor: 'ADMIN'
      },
      {
        link: 'gasConsumption',
        icon: 'local_gas_station',
        title: 'Gas Consumption',
        active: false,
        onlyDisplayFor: 'ADMIN'
      },
      {
        link: 'skippers',
        icon: 'rowing',
        title: 'Skippers',
        active: false,
        onlyDisplayFor: 'USER'
      },
      {
        link: 'reviews',
        icon: 'rate_review',
        title: 'Reviews',
        active: false,
        onlyDisplayFor: 'USER'
      },
      {
        link: 'coupons',
        icon: 'sell',
        title: 'Coupons',
        active: false,
        onlyDisplayFor: 'USER'
      }
    ]
  }

  logOut() {
    this.authService.signOut();
  }

}