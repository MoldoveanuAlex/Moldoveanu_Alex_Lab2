﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Alex_Laborator2.Data;
using Moldoveanu_Alex_Laborator2.Models;

namespace Moldoveanu_Alex_Laborator2.Pages.Borrowings
{
    public class DetailsModel : PageModel
    {
        private readonly Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context _context;

        public DetailsModel(Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context context)
        {
            _context = context;
        }

      public Borrowing Borrowing { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Borrowing == null)
            {
                return NotFound();
            }

            var borrowing = await _context.Borrowing.FirstOrDefaultAsync(m => m.ID == id);
            if (borrowing == null)
            {
                return NotFound();
            }
            else 
            {
                Borrowing = borrowing;
            }
            return Page();
        }
    }
}
