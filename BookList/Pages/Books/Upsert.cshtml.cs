using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookList.Pages.Books
{
    public class UpsertModel : PageModel
    {
        public ApplicationDbContext _db;

        public UpsertModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Book Book { get; set; }

        public async Task<IActionResult> OnGet(int? id)
        {
            Book = new Book();

            if (id == null)
            {
                return Page(); // if the id doesn't exist, go back to the page
            }

            Book = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);

            if (Book == null)
            {
                return NotFound();
            }
            return Page();

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                if (Book.Id == 0)
                {
                    _db.Book.Add(Book);
                }
                else
                {
                    _db.Book.Update(Book); // Updates all properties from the Book object
                }

                await _db.SaveChangesAsync();

                return RedirectToPage("Index"); // Goes to the index page once the updated book is saved in the database
            }
            return RedirectToPage(); // Just goes back to the page you're on

        }
    }
}