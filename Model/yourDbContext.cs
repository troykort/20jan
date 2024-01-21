using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System. Threading.Tasks;
// using Model;

namespace _20jan.Model{
    public class yourDbContext:DbContext{

       
          public yourDbContext(DbContextOptions<yourDbContext> options)
        : base(options)
    {
    }
        public DbSet<dbGebruiker> Gebruikers { get; set; }

            public yourDbContext() { 

            }

            




    }
}