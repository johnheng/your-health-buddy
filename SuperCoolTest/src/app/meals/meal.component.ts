import { Component, Input, OnInit } from '@angular/core';
import { Http, URLSearchParams } from '@angular/http'

@Component({
  selector: 'meal',
  templateUrl: './meal.component.html'
})

export class MealComponent implements OnInit {
  constructor(private _httpService: Http) { }
  @Input() mealName: string;
  
  foods: any;

  ngOnInit() {
    let params = new URLSearchParams();
    params.set('meal', this.mealName);

    this._httpService.get('/api/values/getfoods', { params: params }).subscribe(values => {
      console.log(values.json());
      this.foods = values.json() as string[];
    });
  }
}