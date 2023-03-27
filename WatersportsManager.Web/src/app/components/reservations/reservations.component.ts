import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Reservation } from 'src/app/models/reservation';
import { ReservationService } from 'src/app/services/reservation.service';

@Component({
  selector: 'app-reservations',
  templateUrl: './reservations.component.html',
  styleUrls: ['./reservations.component.scss']
})
export class ReservationsComponent implements OnInit {

  @Output() reservationUpdated = new EventEmitter<any[]>();

  public reservations: any = [];
  reservationToEdit?: Reservation;

  personId: any;

  loading: boolean = false;

  constructor(
    private reservationApi: ReservationService
  ) { }

  ngOnInit(): void {
    this.getReservations();
  }

  getReservations() {
    this.loading = true;
    this.reservationApi.getReservations()
      .then(res => {
        this.reservations = res;
        this.loading = false;
      });
  }

  updateReservationList(reservations: Reservation[]) {
    this.getReservations();
  }

  initNewReservation() {
    this.reservationToEdit = new Reservation();
  }

  editReservation(reservation: Reservation) {
    this.reservationToEdit = reservation;
  }

  deleteReservation(reservation: Reservation) {
    this.reservationApi
      .deleteReservation(reservation)
      .then(res => {
        this.reservationUpdated.emit(res);
        window.location.reload();
      })
  }
}