using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Suciu_Denisa_Labr2.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Full Name")]
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }

        public ICollection<Book>? Books { get; set; }
    }
}
