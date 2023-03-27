import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { BoatType } from 'src/app/models/boatType';
import { Location } from 'src/app/models/location';
import { Person } from 'src/app/models/person';
import { LocationService } from 'src/app/services/location.service';
import { PersonService } from 'src/app/services/person.service';
import { ReservationService } from 'src/app/services/reservation.service';
import { BoatTypeService } from 'src/app/services/boat-type.service';

@Component({
  selector: 'app-edit-reservation',
  templateUrl: './edit-reservation.component.html',
  styleUrls: ['./edit-reservation.component.scss']
})
export class EditReservationComponent {
  @Input() reservation?: any;
  @Output() reservationUpdated = new EventEmitter<any[]>();

  people: Person[] = [];
  boatTypes: BoatType[] = [];
  locations: Location[] = [];

  selectedPerson: any;
  selectedBoatType: any;
  selectedLocation: any;

  constructor(
    private reservationApi: ReservationService,
    private personApi: PersonService,
    private boatTypeApi: BoatTypeService,
    private locationApi: LocationService
  ) { }

  ngOnInit(): void {
    this.getPeople();
    this.getBoatTypes();
    this.getLocations();
  }

  getPeople() {
    this.personApi.getPeople()
      .then(res => {
        this.people = res;
        this.selectedPerson = res[0];
      })
  }

  getBoatTypes() {
    this.boatTypeApi.getBoatTypes()
      .then(res => {
        this.boatTypes = res;
        this.selectedBoatType = res[0];
      })
  }

  getLocations() {
    this.locationApi.getLocations()
      .then(res => {
        this.locations = res;
        this.selectedLocation = res[0];
      })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['reservation'] && changes['reservation'].currentValue) {
      let currentPerson = this.people.find(person => (person.firstName + ' ' + person.lastName) === this.reservation.person);
      let currentBoatType = this.boatTypes.find(boatType => boatType.name === this.reservation.boatType);
      let currentLocation = this.locations.find(location => location.camp === this.reservation.location);
      this.selectedPerson = currentPerson ? currentPerson : this.people[0];
      this.selectedBoatType = currentBoatType ? currentBoatType : this.boatTypes[0];
      this.selectedLocation = currentLocation ? currentLocation : this.locations[0];
    }
  }

  setPerson(person: any) {
    this.selectedPerson = person;
  }

  setBoatType(boatType: any) {
    this.selectedBoatType = boatType;
  }

  setLocation(location: any) {
    this.selectedLocation = location;
  }

  updateReservation(reservation: any) {
    reservation.PersonId = this.selectedPerson.id;
    reservation.BoatTypeId = this.selectedBoatType.id;
    reservation.LocationId = this.selectedLocation.id;
    this.reservationApi
      .updateReservation(reservation)
      .then(res => {
        this.reservationUpdated.emit(res);
        window.location.reload();
      })
  }

  addReservation(reservation: any) {
    reservation.PersonId = this.selectedPerson.id;
    reservation.BoatTypeId = this.selectedBoatType.id;
    reservation.LocationId = this.selectedLocation.id;
    this.reservationApi
      .createReservation(reservation)
      .then(res => {
        this.reservationUpdated.emit(res);
        window.location.reload();
      })
  }


  setIsPaid(value: boolean) {
    this.reservation.isPaid = value;
  }
}
