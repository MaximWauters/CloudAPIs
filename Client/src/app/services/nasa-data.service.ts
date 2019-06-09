import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class NasaDataService {

  private key : string = "sGwtBiunTptp6FycDk96NeLfflELD3UksWWKQmNf";

  constructor(private http: HttpClient) { }

  getData(page: number){
    return this.http.get<IData[]>(`https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&page=${page}&api_key=${this.key}`);
  }

  getDataByDate(date: string){
    return this.http.get<IData[]>(`https://api.nasa.gov/mars-photos/api/v1/rovers/curiosity/photos?earth_date=${date}&api_key=${this.key}`);
  }
}

export interface Camera {
  id: number;
  name: string;
  rover_id: number;
  full_name: string;
}

export interface Camera2 {
  name: string;
  full_name: string;
}

export interface Rover {
  id: number;
  name: string;
  landing_date: string;
  launch_date: string;
  status: string;
  max_sol: number;
  max_date: string;
  total_photos: number;
  cameras: Camera2[];
}

export interface Photo {
  id: number;
  sol: number;
  camera: Camera;
  img_src: string;
  earth_date: string;
  rover: Rover;
}

export interface IData {
  photos: Photo[];
}
