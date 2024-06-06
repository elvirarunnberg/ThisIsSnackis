using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.UserPictures
{
    public class CreateModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _userManager = userManager;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> OnGet()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return NotFound();
            }

            UserPicture = new UserPicture
            {
                UserId = currentUser.UserName
            };

            return Page();
        }

        [BindProperty]
        public IFormFile UploadedImage { get; set; }

        [BindProperty]
        public UserPicture UserPicture { get; set; } = new UserPicture();

        public async Task<IActionResult> OnPostAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return NotFound();
            }

            UserPicture.UserId = currentUser.UserName;

            if (UploadedImage != null)
            {
                if (UploadedImage.Length > 0)
                {
                    // Validera filtyp och storlek
                    var validFileTypes = new[] { "image/jpeg", "image/png", "image/gif" };
                    if (!Array.Exists(validFileTypes, t => t.Equals(UploadedImage.ContentType, StringComparison.OrdinalIgnoreCase)))
                    {
                        ModelState.AddModelError("UploadedImage", "Ogiltig filtyp. Endast JPEG, PNG och GIF är tillåtna.");
                        return Page();
                    }

                    var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                    Directory.CreateDirectory(uploadsFolder);

                    var uniqueFileName = $"{Guid.NewGuid()}_{UploadedImage.FileName}";
                    var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await UploadedImage.CopyToAsync(fileStream);
                    }

                    UserPicture.Image = uniqueFileName;
                }
            }

            _context.UserPicture.Add(UserPicture);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}