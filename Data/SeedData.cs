using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Suciu_Denisa_Labr2.Data;
using Suciu_Denisa_Labr2.Models;
using System;
using System.Linq;

namespace Suciu_Denisa_Labr2.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Suciu_Denisa_Labr2Context(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Suciu_Denisa_Labr2Context>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }

                context.Publisher.AddRange(
                    new Publisher { PublisherName = "Humanitas" },
                    new Publisher { PublisherName = "Nemira" },
                    new Publisher { PublisherName = "Arthur" }
                );
                context.SaveChanges();

                context.Author.AddRange(
                    new Author { FirstName = "Mihai", LastName = "Eminescu" },
                    new Author { FirstName = "Mircea", LastName = "Eliade" }
                );
                context.SaveChanges();

                context.Book.AddRange(
                    new Book
                    {
                        Title = "Luceafărul",
                        Price = 30,
                        PublishingDate = DateTime.Parse("1883-01-01"),
                        PublisherID = context.Publisher.First().ID,
                        AuthorID = context.Author.First().ID
                    },
                    new Book
                    {
                        Title = "Maitreyi",
                        Price = 40,
                        PublishingDate = DateTime.Parse("1933-01-01"),
                        PublisherID = context.Publisher.Skip(1).First().ID,
                        AuthorID = context.Author.Skip(1).First().ID
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
