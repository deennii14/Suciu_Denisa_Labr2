using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suciu_Denisa_Labr2.Models
{
    public class Book
    {
        public int ID { get; set; }

        [Required]
        [StringLength(150, MinimumLength = 3)]
        public string Title { get; set; }

        [Display(Name = "Publishing Date")]
        [DataType(DataType.Date)]
        public DateTime PublishingDate { get; set; }

        [Range(1, 300)]
        public decimal Price { get; set; }

        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }

        public int? AuthorID { get; set; }
        public Author? Author { get; set; }

        public ICollection<Borrowing>? Borrowings { get; set; }
        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
