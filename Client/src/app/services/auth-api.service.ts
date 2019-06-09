import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthApiService {

  apiUrl = "http://localhost:51466/api/photos";
  
  constructor(public http: HttpClient) { }

  postData(credentials, type) {
    return new Promise((resolve, reject) => {
   // const headers = new Headers();
    this.http.post(this.apiUrl + type, JSON.stringify(credentials))
    .subscribe(res => {
         resolve(res);
         console.log(res);
     }, (err) => {
     reject(err);
 });
});

}
}
