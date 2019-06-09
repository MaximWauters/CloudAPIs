import { Component, OnInit } from '@angular/core';
import { IData, NasaDataService } from '../services/nasa-data.service';

@Component({
  selector: 'app-date',
  templateUrl: './date.component.html',
  styleUrls: ['./date.component.scss']
})
export class DateComponent implements OnInit {
  
  findDate: string = '2015-6-3';
  photos: IData[];

  constructor(private dtsvc: NasaDataService) { }

  ngOnInit() {
  }

  // Search functie op date ( querry string )
  doSearch(){
    this.dtsvc.getDataByDate(this.findDate).subscribe(res => {
      this.photos = res;

      console.log(res)
    })
  }

}
