import { Component, OnInit } from '@angular/core';
import { IPhoto, PhotoDataService } from '../services/photo-data.service';

@Component({
  selector: 'app-gallery-db',
  templateUrl: './gallery-db.component.html',
  styleUrls: ['./gallery-db.component.scss']
})
export class GalleryDbComponent implements OnInit {
  photos : IPhoto[];
  photo: IPhoto;

  constructor(private svc: PhotoDataService) { }

  title: string;
  description: string;
  url: string;
  id: number;

  // GET lijst bij laden pagina
  ngOnInit() {
    this.getPhotos();
  }

  // Haal foto's op
  getPhotos(){
    this.svc.getData().subscribe(res => {
      this.photos = res;
      console.log(res);
    })
  }

  // Voeg een foto toe
  VoegToe(){
    var newPhoto = {
      Title: this.title,
      Description: this.description,
      Url: this.url
    }

    this.svc.postPhoto(newPhoto).subscribe(photo => {
      this.photos.push(photo);
    })

    this.getPhotos(); // Door deze GET uit te voeren zien we de toegevoegde record uit de db in de client direct
  }

  UpdateFoto(id: number){
    this.svc.getPhotoById(id).subscribe(res=>{
      this.photo = res;

      this.id = id; // Haal de ID op voor de aan te passen foto

      console.log(this.id);
      //this.title = this.photo.Title;
      //this.description = this.photo.Description;
      //this.url = this.photo.Url;

  });
}

  // Voeg de nieuwe geupdatete foto toe 
  VoegHemToe(){
    /*
    this.svc.getPhotoById(id).subscribe(res=>{
      this.photo = res;

      this.id = this.photo.Id
      this.title = this.photo.Title;
      this.description = this.photo.Description;
      this.url = this.photo.Url;

      console.log(this.photo);

    })
    */
    var updatedPhoto = {
      Id: this.id,
      Title: this.title,
      Description: this.description,
      Url: this.url
    }
    console.log(updatedPhoto);
    this.svc.updatePhoto(updatedPhoto).subscribe(photo => {
      this.photos.push(photo);
      this.getPhotos();
      
    });
    this.photo = undefined;
  }

  // Delete foto
  DeleteFoto(id: number){
    this.svc.deletePhoto(id).subscribe(() => {
      this.getPhotos()
    });
  }

}
