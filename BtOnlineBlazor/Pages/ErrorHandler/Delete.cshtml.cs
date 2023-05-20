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
    public class DeleteModel : PageModel
    {
        private readonly BTOnlineBlazor.Data.ApplicationDbContext _context;

        public DeleteModel(BTOnlineBlazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.ErrorLog == null)
            {
                return NotFound();
            }
            var errorlog = await _context.ErrorLog.FindAsync(id);

            if (errorlog != null)
            {
                ErrorLog = errorlog;
                _context.ErrorLog.Remove(ErrorLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
