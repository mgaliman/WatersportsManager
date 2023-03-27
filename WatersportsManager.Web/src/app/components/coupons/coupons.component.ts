import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-coupons',
  templateUrl: './coupons.component.html',
  styleUrls: ['./coupons.component.scss']
})
export class CouponsComponent implements OnInit {

  date: Date | undefined;

  ngOnInit() {
    this.date = new Date();
    this.date.setDate(this.date.getDate() + 3);
  }

}
