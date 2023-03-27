import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Person } from 'src/app/models/person';
import { AuthService } from 'src/app/services/auth.service';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-people',
  templateUrl: './people.component.html',
  styleUrls: ['./people.component.scss']
})
export class PeopleComponent implements OnInit {

  @Output() peopleUpdated = new EventEmitter<Person[]>();

  public people: any = [];
  personToEdit?: Person;

  personId: any;

  loading: boolean = false;

  constructor(
    private personApi: PersonService,
    private authService: AuthService
  ) { }

  ngOnInit(): void {
    this.personId = this.authService.decodedToken().Id;
    this.getPeople();
  }

  getPeople() {
    this.loading = true;
    this.personApi.getPeople()
      .then(res => {
        this.people = res;
        this.loading = false;
      });
  }

  updatePersonList(people: Person[]) {
    this.getPeople();
  }

  initNewPerson() {
    this.personToEdit = new Person();
  }

  editPerson(person: Person) {
    this.personToEdit = person;
  }

  deletePerson(person: Person) {
    this.personApi
      .deletePerson(person)
      .then(res => {
        this.peopleUpdated.emit(res);
        this.getPeople();
      })
  }
}
