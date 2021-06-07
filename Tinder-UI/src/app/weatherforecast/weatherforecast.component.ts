import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-weatherforecast',
  templateUrl: './weatherforecast.component.html',
  styleUrls: ['./weatherforecast.component.css']
})
export class WeatherforecastComponent implements OnInit {
  forecasts: any;
  constructor(private http: HttpClient) { 


  }

  ngOnInit() {
    this.getForecasts();
  }
  getForecasts(){

    this.http.get('http://localhost:5000/api/WeatherForecast').subscribe(response=>{
      this.forecasts=response;
    }, error=>{
      console.log(error)
    });
  }
}
