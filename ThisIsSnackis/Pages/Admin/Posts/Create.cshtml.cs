using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Posts
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

        public IList<Category> Categories { get; set; }
        public async Task<IActionResult> OnGetAsync()
        {
            Categories = await _context.Category.ToListAsync();

            return Page();
        }


        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Hämta den aktuella användaren
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser != null)
            {
                Post.AuthorId = currentUser.UserName;

                // Hämta användarens bild
                var userPicture = await _context.UserPicture.FirstOrDefaultAsync(up => up.UserId == currentUser.UserName);

                if (userPicture != null)
                {
                    Post.ProfilePicture = Path.Combine("Images", userPicture.Image);  // Tilldela profilbild URL till posten
                }
            }
            else
            {
                return Page();
            }

            // Ställ in aktuellt datum och tid
            Post.Date = DateTime.Now;

            _context.Post.Add(Post);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
