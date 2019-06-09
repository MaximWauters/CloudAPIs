import { Component, OnInit } from '@angular/core';
import {
    AuthService,
    FacebookLoginProvider,
    GoogleLoginProvider
} from 'angular-6-social-login';
import { AuthApiService } from '../services/auth-api.service';
import { UserService } from '../services/user.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss']
})
export class NavBarComponent implements OnInit {
  name : string;

  public responseData: any;

  public userPostData = {
    email: '',
    name: '',
    provider: '',
    provider_id: '',
    provider_pic: '',
    token: '',
    idToken: ''
  };
  constructor(private socialAuthService: AuthService, public authAPIService: AuthApiService, public user: UserService) { }

  ngOnInit() {
  }

  // Data die je terugkrijgt van google
  apiConnection(data) {
    this.userPostData.email = data.email;
    this.userPostData.name = data.name;
    this.userPostData.provider = data.provider;
    this.userPostData.provider_id = data.id;
    this.userPostData.provider_pic = data.image;
    this.userPostData.token = data.token;
    this.userPostData.idToken = data.idToken;
  }

  public socialSignIn(socialPlatform : string) {
    let socialPlatformProvider;
    
    if(socialPlatform == "google"){
      socialPlatformProvider = GoogleLoginProvider.PROVIDER_ID;
    
    }
    
    this.socialAuthService.signIn(socialPlatformProvider).then(
      (userData) => {
        console.log(socialPlatform+" sign in data : " , userData);
        // Now sign-in with userData
        
          this.apiConnection(userData);
       
          this.name = userData.name;
      }
    );

    // POST naar REST API voor auth
    this.authAPIService.postData(this.userPostData, 'signup').then(
      result => {
        this.responseData = result;
          if (this.responseData.userData) {
            this.user.storeData(this.responseData.userData);
          }
       },
      err => {
        console.log('error');
       }
      );
  }

  logout(){
    this.user.logOut();
  }

}
