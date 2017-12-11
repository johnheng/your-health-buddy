import { Component, Input, OnInit } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http'

@Component({
  selector: 'food',
  templateUrl: './food.component.html'
})

export class FoodComponent implements OnInit {
  constructor(private _httpService: Http) { }
  @Input() food: any;
}