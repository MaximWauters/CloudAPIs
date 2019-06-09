import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PhotoDataService {

  constructor(private http: HttpClient) { }

  getData(){
    return this.http.get<IPhoto[]>("http://localhost:51466/api/photos");
  }

  getPhotoById(id: number){
    return this.http.get<IPhoto>(`http://localhost:51466/api/photos/${id}`)
  }

  postPhoto(photo: IPhoto){
    return this.http.post<IPhoto>("http://localhost:51466/api/photos", photo);
  }

  deletePhoto(id: number){
    return this.http.delete<IPhoto>(`http://localhost:51466/api/photos/${id}`);
  }

  updatePhoto(photo: IPhoto){
    return this.http.put<IPhoto>("http://localhost:51466/api/photos/", photo);
  }
}

export interface IPhoto{
  Id?: number,
  Title: string,
  Description: string,
  Url: string
}
