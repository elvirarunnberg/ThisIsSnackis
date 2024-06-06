using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Comments
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

        public async Task <IActionResult> OnGet(int? postId)
        {
            if (postId == null)
            {
                return NotFound();
            }

            // Fyller i Id för inlägget man kommenterar på
            Comment = new Comment { ThePostId = postId.Value };

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser != null)
            {
                Comment.UserId = currentUser.UserName;
            }
            else
            {
                return Page();
            }



            return Page();

        
        }

        [BindProperty]
        public Comment Comment { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Comment.Add(Comment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
