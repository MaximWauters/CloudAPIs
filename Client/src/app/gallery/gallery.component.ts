import { Component, OnInit } from '@angular/core';
import { IData, NasaDataService, Photo } from '../services/nasa-data.service';

@Component({
  selector: 'app-gallery',
  templateUrl: './gallery.component.html',
  styleUrls: ['./gallery.component.scss']
})
export class GalleryComponent implements OnInit {
  show : boolean = true;

  datas : IData[];
  photos: IData[];

  name : string;
  img : string;
  date: string;
  
  pagina : number = 1;

  constructor(private dtsvc: NasaDataService){
    //this.getTheData();
  }

  // Haal de data op
  getTheData(){
    this.dtsvc.getData(this.pagina).subscribe(res => { 
      this.datas = res;
      
      //this.name = res[0].photos[0].rover.name;
      //this.img = res.img_src;

      console.log(res);
    })
  }

  ngOnInit() {
    this.getTheData();
  }

  scrollToTop(){
    //methode om als pagina op het einde is en nieuwe data word ingeladen, telkens word teruggekeerd naar de top
    document.body.scrollTop = document.documentElement.scrollTop = 0;

    var myDiv = document.getElementById('col1');
    myDiv.scrollTop = 0;
  }

  next(){
    this.pagina++;
    this.getTheData();
    this.scrollToTop();
  }

  prev(){
    this.pagina--;
    this.getTheData();
    this.scrollToTop();
  }

}
