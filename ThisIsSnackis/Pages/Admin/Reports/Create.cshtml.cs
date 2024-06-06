using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;
using Microsoft.AspNetCore.Identity;

namespace ThisIsSnackis.Pages.Admin.Reports
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public CreateModel(ThisIsSnackis.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGet(int? postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            Report = new Report { PostId = postId.Value };

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                Report.UserId = currentUser.UserName;
            }
            else
            {
                return Page();
            }

            return Page();
        }

        [BindProperty]
        public Report Report { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Report.CreatedAt = DateTime.Now;

            _context.Report.Add(Report);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Admin/Categorys/Index");
        }
    }
}
