using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Categorys
{
    public class DetailsModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public DetailsModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Category Category { get; set; } = default!;

        public List<Post> Posts { get; set; }
 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var category = await _context.Category.FirstOrDefaultAsync(m => m.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                Category = category;
            }

            Posts = await _context.Post.Where(p => p.TheCategoryId == Category.Id).ToListAsync();

            return Page();
        }
    }
}
