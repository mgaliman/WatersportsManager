import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { Person } from 'src/app/models/person';
import { Reservation } from 'src/app/models/reservation';
import { PersonService } from 'src/app/services/person.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { ReviewService } from 'src/app/services/review.service';

@Component({
  selector: 'app-edit-review',
  templateUrl: './edit-review.component.html',
  styleUrls: ['./edit-review.component.scss']
})
export class EditReviewComponent implements OnInit {
  @Input() review?: any;
  @Output() reviewUpdated = new EventEmitter<any[]>();

  people: Person[] = [];
  reservations: Reservation[] = [];

  selectedPerson: any;
  selectedReservation: any;

  constructor(
    private reviewApi: ReviewService,
    private personApi: PersonService,
    private reservationAPi: ReservationService
  ) { }

  ngOnInit(): void {
    this.getPeople();
    this.getReservations();
  }

  getPeople() {
    this.personApi.getPeople()
      .then(res => {
        this.people = res;
        this.selectedPerson = res[0];
      })
  }

  getReservations() {
    this.reservationAPi.getReservations()
      .then(res => {
        this.reservations = res;
        this.selectedReservation = res[0];
      })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['review'] && changes['review'].currentValue) {
      let currentPerson = this.people.find(person => (person.firstName + ' ' + person.lastName) === this.review.person);
      let currentReservation = this.reservations.find(reservation => reservation.id === this.review.reservationId);
      this.selectedPerson = currentPerson ? currentPerson : this.people[0];
      this.selectedReservation = currentReservation ? currentReservation : this.reservations[0];
    }
  }

  setPerson(person: Person) {
    this.selectedPerson = person;
  }

  setReservation(reservation: Reservation) {
    this.selectedReservation = reservation;
  }

  updateReview(review: any) {
    review.PersonId = this.selectedPerson.id;
    review.ReservationId = this.selectedReservation.id;
    this.reviewApi
      .updateReview(review)
      .then(res => {
        this.reviewUpdated.emit(res);
      })
  }

  addReview(review: any) {
    review.PersonId = this.selectedPerson.id;
    review.ReservationId = this.selectedReservation.id;
    this.reviewApi
      .createReview(review)
      .then(res => {
        this.reviewUpdated.emit(res);
      })
  }
}
