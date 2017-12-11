import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';

import './meals/meal';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _httpService: Http) { }
  meals: string[] = [];
  mealsAndFoods: Meal[];

  totals = {
    carbs: 0,
    fats: 0,
    proteins: 0,
    calories: 0
  }

  ngOnInit() {
    this._httpService.get('/api/values/getmeals').subscribe(values => {
      console.log(values.json());
      this.meals = values.json() as string[];
      this.getTotals();
    });
  }

  getTotals() {
    // console.log(this.mealsAndFoods);
  }
}
