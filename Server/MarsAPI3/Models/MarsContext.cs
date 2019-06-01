using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarsAPI3.Models
{
    public class MarsContext : DbContext
    {
        public MarsContext(DbContextOptions<MarsContext> options)
                                   : base(options)
        {

        }
        public DbSet<Photo> photo { get; set; }

    }
}
