using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models.Db;


namespace BTOnlineBlazor.Pages.ErrorHandler
{
    public class CreateModel : PageModel
    {
        private readonly BTOnlineBlazor.Data.ApplicationDbContext _context;

        public CreateModel(BTOnlineBlazor.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public ErrorLog ErrorLog { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.ErrorLog == null || ErrorLog == null)
            {
                return Page();
            }

            _context.ErrorLog.Add(ErrorLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
