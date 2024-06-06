using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Messages
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

        public async Task<IActionResult> OnGet()
        {
            

            var currentUser = await _userManager.GetUserAsync(User);



            Message = new Message
            {
                SenderId = currentUser.UserName
            };


            return Page();
        }

        [BindProperty]
        public Message Message { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }


            _context.Message.Add(Message);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }

    }
}
