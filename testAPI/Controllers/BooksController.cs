using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using API.Model;
using System.Linq;

namespace API.Controllers
{
    //[Route("api/books")]
    public class BooksController : ControllerBase
    {
        static List<Book> list = new List<Book>();
        static Book[] list2 = new Book[20];

        static BooksController()
        {
            list.Add(new Book()
            {
                Id = 1,
                Title = "The Hobbit",
                ISBN = "1234"
            });

            list.Add(new Book()
            {
                Id = 2,
                Title= "The Hobbit 2",
                ISBN = "234"
            });
        }

        [HttpGet]
        public List<Book> GetBooks()
        {
            return list;
        }


        [Route("{id}")]
        [HttpGet]
        public ActionResult<Book> GetBook(int id)
        {
            var theBook = list.FirstOrDefault(book => book.Id == id);
            if (theBook == null)
                return NotFound();

            return theBook;
        }



        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteBook(int id)
        {
            var theBook = list.FirstOrDefault(book => book.Id == id);
            if (theBook == null)
                return NotFound();

            list.Remove(theBook);
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Book> AddBook([FromBody]Book book)
        {
            //ken er ID aan toe
            var max = list.Max(b => b.Id);
            book.Id = max + 1;
            list.Add(book);
            //return boek met ID
            return Created("", book);
        }
    }
}








