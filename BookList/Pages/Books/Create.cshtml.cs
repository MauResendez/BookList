using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        [BindProperty] // Instantly assumes that the post will get this property
        public Book Book { get; set; }

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if(ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book); // Puts it in a queue
                await _db.SaveChangesAsync(); // Pushes data to the database

                return RedirectToPage("Index"); // Goes to index page
            }
            else
            {
                return Page();
            }
        }
    }
}