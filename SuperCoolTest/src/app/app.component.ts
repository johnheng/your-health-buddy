import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  constructor(private _httpService: Http) { }
  meals: string[] = [];
  ngOnInit() {
    this._httpService.get('/api/values/getmeals').subscribe(values => {
      console.log(values.json());
      this.meals = values.json() as string[];
    });
  }
}
