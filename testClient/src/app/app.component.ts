import { Component, OnInit } from '@angular/core';
import { GetboekenService, IBooks } from './getboeken.service';
import { identifierModuleUrl } from '@angular/compiler';
import { stringify } from '@angular/core/src/render3/util';
import { NONE_TYPE } from '@angular/compiler/src/output/output_ast';
//import { FormsModule } from '@angular/forms';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  boeken: IBooks[];
  boek: IBooks;

  tit: string = "";
  t: string = "";
  desc: string = "";
  pag: number = 0;

  newBook : IBooks;

  constructor(private bcsv : GetboekenService)
  {
    this.getBoeken();
  }

  // GET

  getBoeken(){
    this.bcsv.getBooks().subscribe(res => {
      this.boeken = res;
      console.table(res);
    })
  }

  // POST

  postIt(){
    this.getTheNewBook();
    console.log(this.tit);
  }
                          // id kent hij zelf toe
  getTheNewBook(){      
   var nieuwBoek = { title: this.tit,
                     description: this.desc,
                     pages: this.pag,
                     authorId: 1
                   }

   //this.boeken.push(nieuwBoek);

   console.log(nieuwBoek);
    
    this.bcsv.postBooks(nieuwBoek).subscribe(book => {
      this.boeken.push(book);
    })
  }

  // DELETE

  deleteBook(id: number){
    console.log(id);
    this.bcsv.deleteBook(id).subscribe(() => this.getBoeken());
  }

  // todo: PUT  zorg ervoor dat veranderd veld de data kan 

  updateBook(id: number){
    console.log(id);
    this.bcsv.getBookById(id).subscribe(res =>{
      this.boek = res;
      console.log(this.boek);

      var updatedBoek = {
                     id: this.boek.id,
                     title: "darkness is among us",                         // changed field
                     description: this.boek.description,
                     pages: this.boek.pages,
                     authorId: 1
      }

      console.log(updatedBoek.title);

      //this.boeken.splice()

      this.bcsv.updateBook(updatedBoek).subscribe(() => this.getBoeken());
    })
    
  }

  ngOnInit(){
    
  }

}


