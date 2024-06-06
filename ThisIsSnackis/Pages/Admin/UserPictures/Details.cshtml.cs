using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.UserPictures
{
    public class DetailsModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public DetailsModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public UserPicture UserPicture { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userpicture = await _context.UserPicture.FirstOrDefaultAsync(m => m.Id == id);
            if (userpicture == null)
            {
                return NotFound();
            }
            else
            {
                UserPicture = userpicture;
            }
            return Page();
        }
    }
}
