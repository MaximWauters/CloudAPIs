using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarsAPI3.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarsAPI3.Controllers
{
    [ApiController]
    [Route("api/photos")]
    public class PhotoController : Controller
    {
        public MarsContext _context { get; set; }
        public PhotoController(MarsContext ctxt)
        {
            _context = ctxt;
        }

        // GET alle foto's
        [HttpGet]
        public List<Photo> GetPhoto()
        {
            return _context.photo.ToList();

        }

        // GET foto via de ID
        [Route("{id}")]
        [HttpGet]
        public ActionResult<Photo> GetPhoto(int id)
        {
            var thePhoto = _context.photo.SingleOrDefault(p => p.Id == id);

            if (thePhoto == null)
                return NotFound();

            return thePhoto;
        }

        // POST nieuwe foto
        [HttpPost]
        public ActionResult<Photo> AddPhoto([FromBody]Photo photo)
        {
            if (!ModelState.IsValid) // controlleer de velden op de juiste inhoud, zie models
                return BadRequest(ModelState);

            _context.photo.Add(photo);
            _context.SaveChanges();
            //return boek met ID
            return Created("", photo);
        }

        // Update foto
        [HttpPut]
        public ActionResult<Photo> UpdatePhoto([FromBody]Photo photo)
        {
            //Boek updaten
            _context.photo.Update(photo);
            _context.SaveChanges();
            //return boek met ID
            return Created("", photo);
        }

        // Delete de foto adhv de id
        [Route("{id}")]
        [HttpDelete]
        public IActionResult DeletePhoto(int id)
        {
            var thePhoto = _context.photo.Find(id);
            if (thePhoto == null)
                return NotFound();

            _context.photo.Remove(thePhoto);
            _context.SaveChanges();             // DO NOT FORGET !!!
            return NoContent();
        }

    }
}