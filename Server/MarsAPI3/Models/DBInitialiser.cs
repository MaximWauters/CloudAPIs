using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsAPI3.Models
{
    public class DBInitialiser
    {
        public static void Initialize(MarsContext context)
        {
            //Create the db if not yet exists
            context.Database.EnsureCreated();

            //Are there already photos present ?
            
            if (!context.photo.Any())
            {
                var t = new Photo()
                {
                   Title = "Marsvlak 1",
                   Description = "Lichte heuveling met stenen",
                   Url = "http://mars.jpl.nasa.gov/msl-raw-images/msss/01000/mcam/1000ML0044631200305217E01_DXXX.jpg"
                };

                var t2 = new Photo()
                {
                    Title = "Marsvlak 2",
                    Description = "Veel middelgrote stenen",
                    Url = "http://mars.jpl.nasa.gov/msl-raw-images/msss/01000/mcam/1000MR0044631190503679E04_DXXX.jpg"
                };

                context.photo.Add(t);
                context.photo.Add(t2);
                context.SaveChanges();
                
            }
        }
    }
}
