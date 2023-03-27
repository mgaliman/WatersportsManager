import { Component } from '@angular/core';

@Component({
  selector: 'app-gas-consumption',
  templateUrl: './gas-consumption.component.html',
  styleUrls: ['./gas-consumption.component.scss']
})
export class GasConsumptionComponent {

  gasPrice: number = 2;

  liters: number = 0;

  constructor() { }

}
