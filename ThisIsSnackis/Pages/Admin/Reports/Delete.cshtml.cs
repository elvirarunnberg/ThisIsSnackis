using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Reports
{
    public class DeleteModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public DeleteModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Report Report { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FirstOrDefaultAsync(m => m.Id == id);

            if (report == null)
            {
                return NotFound();
            }
            else
            {
                Report = report;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var report = await _context.Report.FindAsync(id);
            if (report != null)
            {
                Report = report;
                _context.Report.Remove(Report);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
