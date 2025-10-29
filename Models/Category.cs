using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suciu_Denisa_Labr2.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Category Name")]
        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string CategoryName { get; set; }

        public ICollection<BookCategory>? BookCategories { get; set; }
    }
}
