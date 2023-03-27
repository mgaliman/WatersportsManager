import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges } from '@angular/core';
import { Person } from 'src/app/models/person';
import { PriorityType } from 'src/app/models/priorityType';
import { PersonService } from 'src/app/services/person.service';
import { PriorityTypeService } from 'src/app/services/priority-type.service';
import { ReportService } from 'src/app/services/report.service';

@Component({
  selector: 'app-edit-report',
  templateUrl: './edit-report.component.html',
  styleUrls: ['./edit-report.component.scss']
})
export class EditReportComponent implements OnInit {
  @Input() report?: any;
  @Output() reportUpdated = new EventEmitter<any[]>();

  people: Person[] = [];
  priorityTypes: PriorityType[] = [];

  selectedPerson: any;
  selectedPriorityType: any;

  constructor(
    private reportApi: ReportService,
    private personApi: PersonService,
    private priorityTypeApi: PriorityTypeService
  ) { }

  ngOnInit(): void {
    this.getPeople();
    this.getPriorityTypes();
  }

  getPeople() {
    this.personApi.getPeople()
      .then(res => {
        this.people = res;
        this.selectedPerson = res[0];
      })
  }

  getPriorityTypes() {
    this.priorityTypeApi.getPriorityTypes()
      .then(res => {
        this.priorityTypes = res;
        this.selectedPriorityType = res[0];
      })
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['report'] && changes['report'].currentValue) {
      let currentPerson = this.people.find(person => (person.firstName + ' ' + person.lastName) === this.report.person);

      let currentPriorityType = this.priorityTypes.find(priorityType => priorityType.type === this.report.priorityType);
      this.selectedPerson = currentPerson ? currentPerson : this.people[0];
      this.selectedPriorityType = currentPriorityType ? currentPriorityType : this.priorityTypes[0];
    }
  }

  setPerson(person: Person) {
    this.selectedPerson = person;
  }

  setPriorityType(priorityType: PriorityType) {
    this.selectedPriorityType = priorityType;
  }

  updateReport(report: any) {
    report.PersonId = this.selectedPerson.id;
    report.PriorityTypeId = this.selectedPriorityType.id;
    this.reportApi
      .updateReport(report)
      .then(res => {
        this.reportUpdated.emit(res);
      })
  }

  addReport(report: any) {
    report.PersonId = this.selectedPerson.id;
    report.PriorityTypeId = this.selectedPriorityType.id;
    this.reportApi
      .createReport(report)
      .then(res => {
        this.reportUpdated.emit(res);
      })
  }
}
