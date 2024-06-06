using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.UserPictures
{
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public DeleteModel(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [BindProperty]
        public UserPicture UserPicture { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserPicture = await _context.UserPicture.FirstOrDefaultAsync(m => m.Id == id);

            if (UserPicture == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            UserPicture = await _context.UserPicture.FindAsync(id);

            if (UserPicture != null)
            {
                // Ta bort bilden från lagringsplatsen
                if (!string.IsNullOrEmpty(UserPicture.Image))
                {
                    var imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "Images", UserPicture.Image);
                    if (System.IO.File.Exists(imagePath))
                    {
                        System.IO.File.Delete(imagePath);
                    }
                }

                // Ta bort användarbilden från databasen
                _context.UserPicture.Remove(UserPicture);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}