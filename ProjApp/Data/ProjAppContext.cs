using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjApp.Models;

namespace ProjApp.Data
{
    public class ProjAppContext : DbContext
    {
        public ProjAppContext (DbContextOptions<ProjAppContext> options)
            : base(options)
        {
        }

        public DbSet<Car> Car { get; set; }

        public DbSet<Country> Country { get; set; }

        public DbSet<Brand> Brand { get; set; }

    }
}
