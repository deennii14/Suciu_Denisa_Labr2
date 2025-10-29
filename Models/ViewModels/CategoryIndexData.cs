using System.Collections.Generic;

namespace Suciu_Denisa_Labr2.Models
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
