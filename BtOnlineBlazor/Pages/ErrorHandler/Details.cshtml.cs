using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models.Db;

namespace BTOnlineBlazor.Pages.ErrorHandler
{
    public class DetailsModel : PageModel
    {
        private readonly BTOnlineBlazor.Data.ApplicationDbContext _context;

        public DetailsModel(BTOnlineBlazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public ErrorLog ErrorLog { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.ErrorLog == null)
            {
                return NotFound();
            }

            var errorlog = await _context.ErrorLog.FirstOrDefaultAsync(m => m.ErrorId == id);
            if (errorlog == null)
            {
                return NotFound();
            }
            else 
            {
                ErrorLog = errorlog;
            }
            return Page();
        }
    }
}
