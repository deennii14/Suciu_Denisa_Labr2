using Microsoft.AspNetCore.Mvc.RazorPages;
using Suciu_Denisa_Labr2.Data;
using Suciu_Denisa_Labr2.Models;
using System.Collections.Generic;
using System.Linq;

namespace Suciu_Denisa_Labr2.Pages.Books
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Suciu_Denisa_Labr2Context context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories = new HashSet<int>(book.BookCategories.Select(c => c.CategoryID));

            AssignedCategoryDataList = allCategories.Select(cat => new AssignedCategoryData
            {
                CategoryID = cat.ID,
                Name = cat.CategoryName,
                Assigned = bookCategories.Contains(cat.ID)
            }).ToList();
        }

        public void UpdateBookCategories(
            Suciu_Denisa_Labr2Context context,
            string[] selectedCategories,
            Book bookToUpdate)
        {
            if (selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }

            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var bookCategories = new HashSet<int>
                (bookToUpdate.BookCategories.Select(c => c.CategoryID));

            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(
                            new BookCategory { BookID = bookToUpdate.ID, CategoryID = cat.ID });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory categoryToRemove = bookToUpdate
                            .BookCategories
                            .FirstOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(categoryToRemove);
                    }
                }
            }
        }
    }
}
