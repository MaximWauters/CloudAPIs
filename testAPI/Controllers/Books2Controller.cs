using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class Books2Controller : ControllerBase
    {
        public LibraryContext _context { get; set; }
        public Books2Controller(LibraryContext ctxt)
        {
            _context = ctxt;
        }

        
        [HttpGet]
        public List<Book> GetBooks()
        {
            return _context.Books.ToList();
            
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Book> GetBook(int id)
        {
            var theBook = _context.Books.Include(b => b.Author)
                                        .SingleOrDefault(b => b.Id == id);
            if (theBook == null)
                return NotFound();

            return theBook;
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var theBook = _context.Books.Find(id);
            if (theBook == null)
                return NotFound();

            _context.Books.Remove(theBook);
            _context.SaveChanges();             // DO NOT FORGET !!!
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody]Book book)
        {
            if (!ModelState.IsValid) // controlleer de velden op de juiste inhoud, zie models
                return BadRequest(ModelState);

            _context.Books.Add(book);
            _context.SaveChanges();
            //return boek met ID
            return Created("", book);
        }

        [HttpPut]
        public ActionResult<Book> UpdateBook([FromBody]Book book)
        {
            //Boek updaten
            _context.Books.Update(book);
            _context.SaveChanges();
            //return boek met ID
            return Created("", book);
        }

        [Route("{bookId}/author")]
        [HttpGet]
        public ActionResult<Book> GetAuthorForBook(int bookId)
        {
            var theBook = _context.Books.Include(b => b.Author)
                                        .SingleOrDefault(b => b.Id == bookId);

            if (theBook == null)
                return NotFound();

            return theBook;
        }

        /*
        //[Route("{Id}")]
        [HttpGet]
        public List<Book> GetBooks(string isbn, int? pages, string sort, string direction, int pageNr = 0, int length = 2)
        {
            IQueryable<Book> query = _context.Books;

            if (!string.IsNullOrEmpty(isbn))
                query = query.Where(b => b.ISBN == isbn);

            if (pages != null)
                query = query.Where(b => b.Pages == pages);

            switch (sort)
            {
                case "title":
                    if(direction == "asc")
                        query = query.OrderBy(b => b.Title);
                    else
                        query = query.OrderByDescending(b => b.Title);
                    break;

            }

            query = query.Skip(pageNr * length);
            query = query.Take(length);

            return query.ToList();
        }*/
    }
}
