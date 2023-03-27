import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { AppRoutingModule } from './app-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgToastModule } from 'ng-angular-popup';
import { TokenInterceptor } from './interceptors/token.interceptor';
import { LayoutComponent } from './components/layout/layout.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { TopbarComponent } from './components/topbar/topbar.component';
import { HomeComponent } from './components/home/home.component';
import { PeopleComponent } from './components/people/people.component';
import { BoatTypesComponent } from './components/boat-types/boat-types.component';
import { MapComponent } from './components/map/map.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { ReportsComponent } from './components/reports/reports.component';
import { GasConsumptionComponent } from './components/gas-consumption/gas-consumption.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { SkippersComponent } from './components/skippers/skippers.component';
import { CouponsComponent } from './components/coupons/coupons.component';
import { EditPersonComponent } from './components/edit-person/edit-person.component';
import { EditBoatTypeComponent } from './components/edit-boat-type/edit-boat-type.component';
import { GoogleMapsModule } from '@angular/google-maps';
import { EditReservationComponent } from './components/edit-reservation/edit-reservation.component';
import { EditReportComponent } from './components/edit-report/edit-report.component';
import { LoaderComponent } from './components/loader/loader.component';
import { EditReviewComponent } from './components/edit-review/edit-review.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    LayoutComponent,
    SidebarComponent,
    TopbarComponent,
    HomeComponent,
    PeopleComponent,
    BoatTypesComponent,
    MapComponent,
    ReservationsComponent,
    ReportsComponent,
    GasConsumptionComponent,
    ReviewsComponent,
    SkippersComponent,
    CouponsComponent,
    EditPersonComponent,
    EditBoatTypeComponent,
    EditReservationComponent,
    EditReportComponent,
    LoaderComponent,
    EditReviewComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    NgToastModule,
    FormsModule,
    GoogleMapsModule
  ],
  providers: [{
    provide: HTTP_INTERCEPTORS,
    useClass: TokenInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent],
})
export class AppModule { }
