using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Labr2.Data;
using Suciu_Denisa_Labr2.Models;

namespace Suciu_Denisa_Labr2.Pages.Books
{
    public class DetailsModel : PageModel
    {
        private readonly Suciu_Denisa_Labr2Context _context;

        public DetailsModel(Suciu_Denisa_Labr2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Book = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                    .ThenInclude(bc => bc.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }

            return Page();
        }
    }
}
