using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Alex_Laborator2.Data;
using Moldoveanu_Alex_Laborator2.Models;

namespace Moldoveanu_Alex_Laborator2.Pages.Books
{
    public class EditModel : BookCategoriesPageModel
    {
        private readonly Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context _context;

        public EditModel(Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            //var book =  await _context.Book.FirstOrDefaultAsync(m => m.ID == id);

            Book = await _context.Book
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories).ThenInclude(b => b.Category)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Book == null)
            {
                return NotFound();
            }
            //Book = book;

            PopulateAssignedCategoryData(_context, Book);

            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.FirstName + " " + x.LastName
            });


            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");
            ViewData["PublisherID"] = new SelectList(_context.Set<Publisher>(), "ID", "PublisherName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.


        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(Book.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }
        */

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectedCategories)
        {
            if (id == null) 
            { 
                return NotFound(); 
            }

            var bookToUpdate = await _context.Book
                .Include(i => i.Publisher)
                .Include(i => i.BookCategories)
                .ThenInclude(i => i.Category)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (bookToUpdate == null) 
            { 
                return NotFound();
            }

            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "Book",
                i => i.Title, 
                i => i.Author,
                i => i.Price, 
                i => i.PublishingDate, 
                i => i.Publisher)) 
            { 
                UpdateBookCategories(_context, selectedCategories, bookToUpdate); 
                await _context.SaveChangesAsync(); 
                return RedirectToPage("./Index"); 
            }

            UpdateBookCategories(_context, selectedCategories, bookToUpdate); 
            PopulateAssignedCategoryData(_context, bookToUpdate); 
            return Page(); 
        } 
        
        private bool BookExists(int id)
        {
          return _context.Book.Any(e => e.ID == id);
        }
        
    }
}
