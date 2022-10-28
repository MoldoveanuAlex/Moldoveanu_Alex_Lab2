using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Moldoveanu_Alex_Laborator2.Data;
using Moldoveanu_Alex_Laborator2.Models;

namespace Moldoveanu_Alex_Laborator2.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context _context;

        public CreateModel(Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Category Category { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Category.Add(Category);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
