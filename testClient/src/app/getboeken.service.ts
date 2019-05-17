import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class GetboekenService {

  constructor(private http: HttpClient) {

   }

   getBooks(){
     return this.http.get<IBooks[]>("http://localhost:5000/api/books");
   }

   // voor de put vaar je 1 boek op volgens de ID.

   getBookById(id: number){
     return this.http.get<IBooks>(`http://localhost:5000/api/books/${id}`)
   }

   postBooks(book: IBooks){
     return this.http.post<IBooks>("http://localhost:5000/api/books", book);
   }

   deleteBook(id: number){
     return this.http.delete<IBooks>(`http://localhost:5000/api/books/${id}`);
   }

   // TODO
   updateBook(book: IBooks){
     return this.http.put(`http://localhost:5000/api/books/`, book);
   }

   ngOnInit() {
    this.getBooks();
  }
}

export interface IBooks {
  id?: number,
  title: string,
  isbn?: string,
  pages?: number,
  description?: string,
  authorId?: number,
  author?: Author
}

export interface Author {
  id?: number,
  naam?: string
}