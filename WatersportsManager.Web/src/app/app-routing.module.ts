import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BoatTypesComponent } from './components/boat-types/boat-types.component';
import { CouponsComponent } from './components/coupons/coupons.component';
import { EditPersonComponent } from './components/edit-person/edit-person.component';
import { GasConsumptionComponent } from './components/gas-consumption/gas-consumption.component';
import { HomeComponent } from './components/home/home.component';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { MapComponent } from './components/map/map.component';
import { PeopleComponent } from './components/people/people.component';
import { ReportsComponent } from './components/reports/reports.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { ReviewsComponent } from './components/reviews/reviews.component';
import { SignupComponent } from './components/signup/signup.component';
import { SkippersComponent } from './components/skippers/skippers.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  { path: '', redirectTo: 'home', pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  {
    path: '', component: LayoutComponent, canActivate: [AuthGuard], children: [
      { path: 'home', component: HomeComponent, canActivate: [AuthGuard] },
      { path: 'people', component: PeopleComponent, canActivate: [AuthGuard] },
      { path: 'boat-types', component: BoatTypesComponent, canActivate: [AuthGuard] },
      { path: 'map', component: MapComponent, canActivate: [AuthGuard] },
      { path: 'reservations', component: ReservationsComponent, canActivate: [AuthGuard] },
      { path: 'reports', component: ReportsComponent, canActivate: [AuthGuard] },
      { path: 'gasConsumption', component: GasConsumptionComponent, canActivate: [AuthGuard] },
      { path: 'skippers', component: SkippersComponent, canActivate: [AuthGuard] },
      { path: 'reviews', component: ReviewsComponent, canActivate: [AuthGuard] },
      { path: 'coupons', component: CouponsComponent, canActivate: [AuthGuard] },
      { path: 'editPerson', component: EditPersonComponent, canActivate: [AuthGuard] }
    ]
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule { }
