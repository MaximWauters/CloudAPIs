using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class Book
    {
        public int Id { get; set; }

        [Required] // verplicht veld met lengte 30
        [StringLength(30)]
        public string Title{ get; set; }

        public string ISBN { get; set; }
        [Required]
        [Range(1,3000)]
        public int Pages { get; set; }

        public string Description { get; set; }

        [Required]
        public int? AuthorId { get; set; }

        public Author Author { get; set; }
    }
}
