using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Labr2.Models;

namespace Suciu_Denisa_Labr2.Data
{
    public class Suciu_Denisa_Labr2Context : DbContext
    {
        public Suciu_Denisa_Labr2Context (DbContextOptions<Suciu_Denisa_Labr2Context> options)
            : base(options)
        {
        }

        public DbSet<Suciu_Denisa_Labr2.Models.Book> Book { get; set; } = default!;
        public DbSet<Suciu_Denisa_Labr2.Models.Category> Category { get; set; } = default!;
    }
}
