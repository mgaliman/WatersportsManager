import { Component, Input, OnInit } from '@angular/core';
import { Price } from 'src/app/models/price';
import { BoatTypeService } from 'src/app/services/boat-type.service';
import { PriceService } from 'src/app/services/price.service';

@Component({
  selector: 'app-edit-boat-type',
  templateUrl: './edit-boat-type.component.html',
  styleUrls: ['./edit-boat-type.component.scss']
})
export class EditBoatTypeComponent implements OnInit {
  @Input() boatType?: any;

  prices: Price[] = [];
  selectedPrice: any;

  constructor(
    private boatTypeApi: BoatTypeService,
    private priceApi: PriceService
  ) { }

  ngOnInit(): void {
    this.getPrices();
  }

  getPrices() {
    this.priceApi.getPrices()
      .then(res => {
        this.prices = res;
        this.selectedPrice = res[0];
      })
  }

  setPrice(priceId: number) {
    this.selectedPrice = this.prices.find(price => price.id === priceId);
  }

  updateBoatType(boatType: any) {
    boatType.PriceId = this.selectedPrice.id;
    this.boatTypeApi
      .updateBoatType(boatType)
      .then(res => {
        window.location.reload();
      })
  }

  createBoatType(boatType: any) {
    boatType.PriceId = this.selectedPrice.id;
    this.boatTypeApi.createBoatType(boatType)
      .then(res => {
        window.location.reload();
      })
  }

  isFunctionalChange(value: boolean) {
    this.boatType.isFunctional = value;
  }
}
