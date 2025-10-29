using Suciu_Denisa_Labr2.Models;
using System.Collections.Generic;

namespace Suciu_Denisa_Lab2.Models.ViewModels
{
    public class PublisherIndexData
    {
        public IEnumerable<Publisher> Publishers { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
