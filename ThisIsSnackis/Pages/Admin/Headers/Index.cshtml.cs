﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ThisIsSnackis.Data;
using ThisIsSnackis.Models;

namespace ThisIsSnackis.Pages.Admin.Headers
{
    public class IndexModel : PageModel
    {
        private readonly ThisIsSnackis.Data.ApplicationDbContext _context;

        public IndexModel(ThisIsSnackis.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Header> Header { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Header = await _context.Header.ToListAsync();
        }
    }
}
