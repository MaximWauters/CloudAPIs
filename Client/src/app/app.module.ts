import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule }    from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from "@angular/router";
import {FormsModule} from '@angular/forms';
import { DateComponent } from './date/date.component';
import { MDBBootstrapModule } from 'angular-bootstrap-md';
import { GalleryComponent } from './gallery/gallery.component';
import { HomeComponent } from './home/home.component'
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { GalleryDbComponent } from './gallery-db/gallery-db.component';
import {
  SocialLoginModule,
  AuthServiceConfig,
  GoogleLoginProvider,
  FacebookLoginProvider,
} from "angular-6-social-login";

export function getAuthServiceConfigs() {
  let config = new AuthServiceConfig(
      [
        {
          id: FacebookLoginProvider.PROVIDER_ID,
          provider: new FacebookLoginProvider("Your-Facebook-app-id")
        },
        {
          id: GoogleLoginProvider.PROVIDER_ID,
          provider: new GoogleLoginProvider("211560243540-0eicjiisai5u7cgv9qjdp71ahf0e4tvq.apps.googleusercontent.com")
        }
      ]
  );
  return config;
}

@NgModule({
  declarations: [
    AppComponent,
    DateComponent,
    GalleryComponent,
    HomeComponent,
    PageNotFoundComponent,
    NavBarComponent,
    GalleryDbComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    SocialLoginModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent},
      { path: '', redirectTo: 'home', pathMatch: 'full'},
      { path: 'gallery', component: GalleryComponent},
      { path: 'list', component: GalleryDbComponent},
      { path: "**", component: PageNotFoundComponent}
    ], { useHash: true }),
    FormsModule,
    MDBBootstrapModule.forRoot()
    
  ],
  providers: [{provide: AuthServiceConfig, useFactory: getAuthServiceConfigs}],
  bootstrap: [AppComponent]
})
export class AppModule { }

