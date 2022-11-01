﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context _context;

        public IndexModel(Moldoveanu_Alex_Laborator2.Data.Moldoveanu_Alex_Laborator2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }
        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();


            var authorList = _context.Author.Select(x => new
            {
                x.ID,
                FullName = x.FirstName + " " + x.LastName
            });

            ViewData["AuthorID"] = new SelectList(authorList, "ID", "FullName");

            BookD.Books = await _context.Book
                .Include(b => b.Author)
                .Include(b => b.Publisher)
                .Include(b => b.BookCategories)
                .ThenInclude(b => b.Category)
                .AsNoTracking()
                .OrderBy(b => b.Title)
                .ToListAsync();
            
            if (id != null) 
            { 
                BookID = id.Value; 
                Book book = BookD.Books
                    .Where(i => i.ID == id.Value).Single(); 
                BookD.Categories = book.BookCategories.Select(s => s.Category); }
        }



        /*
        public async Task OnGetAsync()
        {
            if (_context.Book != null)
            {
                Book = await _context.Book
                    .Include(b=>b.Author)
                    .Include(b=>b.Publisher)
                    .ToListAsync();
            }
        }
        */
    }
}
