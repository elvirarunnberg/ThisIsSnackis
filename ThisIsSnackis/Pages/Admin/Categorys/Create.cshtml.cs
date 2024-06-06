using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Categorys
{
    public class CreateModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public CreateModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Category Category { get; set; } = new Category();

        public IActionResult OnGet()
        {

            return Page();
        }


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
