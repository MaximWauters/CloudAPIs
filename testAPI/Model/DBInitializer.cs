using Microsoft.AspNetCore.Cors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Model
{
    public class DBInitializer
    {
        public static void Initialize(LibraryContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //Are there already books present ?
            if (!context.Books.Any())
            {
                var author = new Author()
                {
                    Name = "J.R.R.Tolkien"
                };
                //context.Authors.Add(author);

                var book = new Book()
                {
                    Title = "The Hobbit",
                    ISBN = "1234",
                    Author = author
                };

                var book2 = new Book()
                {
                    Title = "Lord o/t Rings",
                    ISBN = "1234-123-123-99",
                    Author = author
                };

                context.Books.Add(book);
                context.Books.Add(book2);
                context.SaveChanges();
            }
        }
    }
}
