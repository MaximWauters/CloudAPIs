using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        public LibraryContext _context { get; set; }
        public AuthorsController(LibraryContext ctxt)
        {
            _context = ctxt;
        }

        [HttpGet]
        public List<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        [Route("{id}")]
        [HttpGet]
        public ActionResult<Author> GetAuthor(int id)
        {
            var theAuthor = _context.Authors.Find(id);
            if (theAuthor == null)
                return NotFound();

            return theAuthor;
        }

        [Route("{authorId}/books")]
        [HttpGet]
        public ActionResult<List<Book>> GetBooksForAuthor(int authorId)
        {
            var theAuthor = _context.Authors.Include(a => a.Books)
                                            .SingleOrDefault(a => a.Id == authorId);

            if (theAuthor == null)
                return NotFound();

            return theAuthor.Books.ToList();
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeleteAuthor(int id)
        {
            var theAuthor = _context.Authors.Find(id);
            if (theAuthor == null)
                return NotFound();

            _context.Authors.Remove(theAuthor);
            _context.SaveChanges();             // DO NOT FORGET !!!
            return NoContent();
        }

        [HttpPost]
        public ActionResult<Author> AddAuthor([FromBody]Author Author)
        {
            _context.Authors.Add(Author);
            _context.SaveChanges();
            //return boek met ID
            return Created("", Author);
        }

        [HttpPut]
        public ActionResult<Author> UpdateAuthor([FromBody]Author Author)
        {
            //Boek updaten
            _context.Authors.Update(Author);
            _context.SaveChanges();
            //return boek met ID
            return Created("", Author);
        }
    }
}