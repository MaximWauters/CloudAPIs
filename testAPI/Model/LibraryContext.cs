using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) 
                                    : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }
    }
}
