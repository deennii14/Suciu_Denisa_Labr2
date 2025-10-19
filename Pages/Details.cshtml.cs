using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Suciu_Denisa_Labr2.Data;
using Suciu_Denisa_Labr2.Models;

namespace Suciu_Denisa_Labr2.Pages
{
    public class DetailsModel : PageModel
    {
        private readonly Suciu_Denisa_Labr2.Data.Suciu_Denisa_Labr2Context _context;

        public DetailsModel(Suciu_Denisa_Labr2.Data.Suciu_Denisa_Labr2Context context)
        {
            _context = context;
        }

        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FirstOrDefaultAsync(m => m.ID == id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                Book = book;
            }
            return Page();
        }
    }
}
