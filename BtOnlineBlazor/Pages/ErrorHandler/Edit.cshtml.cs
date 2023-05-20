using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models.Db;

namespace BTOnlineBlazor.Pages.ErrorHandler
{
    public class EditModel : PageModel
    {
        private readonly BTOnlineBlazor.Data.ApplicationDbContext _context;

        public EditModel(BTOnlineBlazor.Data.ApplicationDbContext context)
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

            var errorlog =  await _context.ErrorLog.FirstOrDefaultAsync(m => m.ErrorId == id);
            if (errorlog == null)
            {
                return NotFound();
            }
            ErrorLog = errorlog;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(ErrorLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ErrorLogExists(ErrorLog.ErrorId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ErrorLogExists(int id)
        {
          return (_context.ErrorLog?.Any(e => e.ErrorId == id)).GetValueOrDefault();
        }
    }
}
