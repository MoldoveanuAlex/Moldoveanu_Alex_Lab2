using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Alex_Laborator2.Models;

namespace Moldoveanu_Alex_Laborator2.Data
{
    public class Moldoveanu_Alex_Laborator2Context : DbContext
    {
        public Moldoveanu_Alex_Laborator2Context (DbContextOptions<Moldoveanu_Alex_Laborator2Context> options)
            : base(options)
        {
        }

        public DbSet<Moldoveanu_Alex_Laborator2.Models.Book> Book { get; set; } = default!;

        public DbSet<Moldoveanu_Alex_Laborator2.Models.Publisher> Publisher { get; set; }

        public DbSet<Moldoveanu_Alex_Laborator2.Models.Author> Author { get; set; }
    }
}
