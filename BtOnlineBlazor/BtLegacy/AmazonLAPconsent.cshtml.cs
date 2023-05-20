using BTOnlineBlazor.App_Code;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace BTOnlineBlazor.Pages
{
    public class AmazonLAPconsentModel : PageModel
    {

        private readonly BtDbContext _context;
        private readonly ErrorReporterService errReport;

        protected AccountReviewData mAccountData = null!;

        public BtDbContext Context { get { return _context; } }

        [BindProperty]
        public AccountReviewListItem[] AccountDataList { get => mAccountData.AccountData; }

        [BindProperty]

        public int Count { get=> mAccountData.Count; }

        public AmazonLAPconsentModel([FromServices] BtDbContext context, [FromServices] ErrorReporterService err)
        {
            _context = context;
            errReport = err;            
        }

        private Task<bool> Initialize()
        {
            string? userId = Request.Query["AccountID"];

            mAccountData = new AccountReviewData(_context, errReport);

            Account? account = AccountManagerService.GetAccount(userId, _context, errReport);

            if (account is not null)

            {
                mAccountData.AccountId = account.UserId.ToString();
                mAccountData.LoadData();
            }

            return Task.FromResult(true);
        }
       

        //public IActionResult OnGet()
        //{
        //    return Page();
        //}

        public async Task<IActionResult> OnGetAsync()
        {
            await Initialize();
            return Page();
        }

        public void Dispose()
        {

        }

    }
}
