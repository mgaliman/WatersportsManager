import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { Location } from 'src/app/models/location';
import { Person } from 'src/app/models/person';
import { Role } from 'src/app/models/role';
import { LocationService } from 'src/app/services/location.service';
import { PersonService } from 'src/app/services/person.service';
import { RoleService } from 'src/app/services/role.service';

@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.scss']
})
export class EditPersonComponent implements OnInit, OnChanges {
  @Input() person?: any;
  @Output() peopleUpdated = new EventEmitter<Person[]>();

  roles: Role[] = [];
  locations: Location[] = [];

  selectedRole: any;
  selectedLocation: any;
  selectedIsSkipper: any;

  constructor(
    private personApi: PersonService,
    private roleApi: RoleService,
    private locationAPi: LocationService
  ) { }

  ngOnInit(): void {
    this.getRoles();
    this.getLocations();
  }

  getRoles() {
    this.roleApi.getRoles()
      .then(res => {
        this.roles = res;
        this.selectedRole = res[0];
      })
  }

  getLocations() {
    this.locationAPi.getLocations()
      .then(res => {
        this.locations = res;
        this.selectedLocation = res[0];
      })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['person'] && changes['person'].currentValue) {
      let currentRole = this.roles.find(role => role.code === this.person.role);
      let currentLocation = this.locations.find(location => location.camp === this.person.location);
      this.selectedRole = currentRole ? currentRole : this.roles[0];
      this.selectedLocation = currentLocation ? currentLocation : this.locations[0];
      this.selectedIsSkipper = this.person.isSkipper || false;
    }
  }

  setRole(roleId: number) {
    this.selectedRole = this.roles.find(role => role.id === roleId);
  }

  setLocation(locationId: number) {
    this.selectedLocation = this.locations.find(location => location.id === locationId);
  }

  updatePerson(person: any) {
    person.RoleId = this.selectedRole.id;
    person.LocationId = this.selectedLocation.id;
    person.IsSkipper = this.selectedIsSkipper;
    this.personApi
      .updatePerson(person)
      .then(res => {
        this.peopleUpdated.emit(res);
        window.location.reload();
      })
  }

  changeIsSkipper(value: boolean) {
    this.selectedIsSkipper = value;
  }
}
