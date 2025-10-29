using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Labr2.Models;

namespace Suciu_Denisa_Labr2.Data
{
    public class Suciu_Denisa_Labr2Context : DbContext
    {
        public Suciu_Denisa_Labr2Context(DbContextOptions<Suciu_Denisa_Labr2Context> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<BookCategory> BookCategory { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<Publisher> Publisher { get; set; }


    }
}
