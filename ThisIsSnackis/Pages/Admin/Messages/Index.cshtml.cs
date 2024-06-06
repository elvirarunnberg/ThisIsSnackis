using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;
using Microsoft.AspNetCore.Identity;

namespace ThisIsSnackis.Pages.Admin.Messages
{
    public class IndexModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public IndexModel(ThisIsSnackis.Data.ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<Message> Message { get;set; } = default!;
        public IList<Message> SentMessages { get; set; } = default!;
        public IList<Message> ReceivedMessages { get; set; } = default!;

        public async Task OnGetAsync()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return;
            }

            var sentMessages = await _context.Message.Where(m => m.SenderId == currentUser.UserName).ToListAsync();
            var receivedMessages = await _context.Message.Where(m => m.ReciverId == currentUser.UserName).ToListAsync();

            // Lägg till listorna i modellen för att skickas till vyn
            SentMessages = sentMessages;
            ReceivedMessages = receivedMessages;
        }
    }
}
