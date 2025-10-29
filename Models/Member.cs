using System.ComponentModel.DataAnnotations;

namespace Suciu_Denisa_Labr2.Models
{
    public class Member
    {
        public int ID { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        // corect: Address, nu Adress
        public string? Address { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }

        [Display(Name = "Full Name")]
        public string? FullName
        {
            get
            {
                return (FirstName ?? "") + " " + (LastName ?? "");
            }
        }

        public ICollection<Borrowing>? Borrowings { get; set; }
    }
}
