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
    public class ErrorLogViewerModel : PageModel
    {
        private readonly BTOnlineBlazor.Data.BtDbContext _context;

        public ErrorLogViewerModel(BTOnlineBlazor.Data.BtDbContext context)
        {
            _context = context;
        }

        public IList<ErrorLog> ErrorLog { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.ErrorLogs != null)
            {
                ErrorLog = await _context.ErrorLogs.ToListAsync();
            }
        }
    }
}
