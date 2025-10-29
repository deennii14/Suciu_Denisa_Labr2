using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Lab2.Models.ViewModels;
using Suciu_Denisa_Labr2.Data;
using Suciu_Denisa_Labr2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Suciu_Denisa_Labr2.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly Suciu_Denisa_Labr2.Data.Suciu_Denisa_Labr2Context _context;

        public IndexModel(Suciu_Denisa_Labr2.Data.Suciu_Denisa_Labr2Context context)
        {
            _context = context;
        }

        public PublisherIndexData PublisherData { get; set; }
        public int PublisherID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            PublisherData = new PublisherIndexData();

            PublisherData.Publishers = await _context.Publisher
                .Include(p => p.Books)
                    .ThenInclude(b => b.Author)
                .AsNoTracking()
                .OrderBy(p => p.PublisherName)
                .ToListAsync();

            if (id != null)
            {
                PublisherID = id.Value;
                Publisher publisher = PublisherData.Publishers
                    .Where(p => p.ID == id.Value)
                    .Single();

                PublisherData.Books = publisher.Books;
            }
        }
    }
}
