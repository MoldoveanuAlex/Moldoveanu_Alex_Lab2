﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Moldoveanu_Alex_Laborator2.Data;
using Moldoveanu_Alex_Laborator2.Models;

namespace Moldoveanu_Alex_Laborator2.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context _context;

        public IndexModel(Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Author> Author { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Author != null)
            {
                Author = await _context.Author.ToListAsync();
            }
        }
    }
}
