import { Component, OnInit } from '@angular/core';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-skippers',
  templateUrl: './skippers.component.html',
  styleUrls: ['./skippers.component.scss']
})
export class SkippersComponent implements OnInit {

  public people: any = [];

  loading: boolean = false;

  constructor(
    private personApi: PersonService
  ) { }

  ngOnInit(): void {
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

}
