import { Component, OnInit } from '@angular/core';
import { BoatType } from 'src/app/models/boatType';
import { BoatTypeService } from 'src/app/services/boat-type.service';

@Component({
  selector: 'app-boats',
  templateUrl: './boat-types.component.html',
  styleUrls: ['./boat-types.component.scss']
})
export class BoatTypesComponent implements OnInit {

  public boatTypes: any = [];
  boatTypeToEdit?: BoatType;

  personId: any;

  loading: boolean = false;

  constructor(
    private boatTypeApi: BoatTypeService
  ) { }

  ngOnInit(): void {
    this.getBoatTypes();
  }

  getBoatTypes() {
    this.loading = true;
    this.boatTypeApi.getBoatTypes()
      .then(res => {
        this.boatTypes = res;
        this.loading = false;
      });
  }

  updateBoatTypeList(boatTypes: BoatType[]) {
    this.getBoatTypes();
  }

  initNewBoatType() {
    this.boatTypeToEdit = new BoatType();
  }

  editBoatType(boatType: BoatType) {
    this.boatTypeToEdit = { ...boatType };
  }

  deleteBoatType(boatType: BoatType) {
    this.boatTypeApi
      .deleteBoatType(boatType)
      .then(res => {
        window.location.reload();
      })
  }
}
