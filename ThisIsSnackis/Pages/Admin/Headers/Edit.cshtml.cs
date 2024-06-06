using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Headers
{
    public class EditModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public EditModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Header Header { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var header =  await _context.Header.FirstOrDefaultAsync(m => m.Id == id);
            if (header == null)
            {
                return NotFound();
            }
            Header = header;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Header).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeaderExists(Header.Id))
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

        private bool HeaderExists(int id)
        {
            return _context.Header.Any(e => e.Id == id);
        }
    }
}
