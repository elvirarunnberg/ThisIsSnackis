using System;
using System.Collections.Generic;
using System.IO; // Lägg till detta
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Posts
{
    public class DetailsModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public DetailsModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Post Post { get; set; }
        public string ProfilePictureUrl { get; set; }

        [BindProperty]
        public List<Comment> Comments { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Post.FirstOrDefaultAsync(m => m.Id == id);
            if (Post == null)
            {
                return NotFound();
            }

            var userPicture = await _context.UserPicture.FirstOrDefaultAsync(up => up.UserId == Post.AuthorId);
            if (userPicture != null)
            {
                ProfilePictureUrl = Path.Combine("/Images", userPicture.Image);  // Uppdaterad sökväg
            }

            Comments = await _context.Comment.Where(p => p.ThePostId == Post.Id).ToListAsync();

            return Page();
        }
    }
}