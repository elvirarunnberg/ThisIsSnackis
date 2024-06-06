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

namespace ThisIsSnackis.Pages.Admin.UserPictures
{
    public class EditModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public EditModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public UserPicture UserPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userpicture =  await _context.UserPicture.FirstOrDefaultAsync(m => m.Id == id);
            if (userpicture == null)
            {
                return NotFound();
            }
            UserPicture = userpicture;
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

            _context.Attach(UserPicture).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserPictureExists(UserPicture.Id))
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

        private bool UserPictureExists(int id)
        {
            return _context.UserPicture.Any(e => e.Id == id);
        }
    }
}
