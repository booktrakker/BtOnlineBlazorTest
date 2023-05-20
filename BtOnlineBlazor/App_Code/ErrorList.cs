using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Models.Db;
using BTOnlineBlazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BTOnlineBlazor.App_Code
{
    public class ErrorList
    {
        private readonly IDbContextFactory<BtDbContext> _dbContextFactory;

        private ErrorLog[] ErrorLog = null!;
        private readonly ErrorReporterService errReport;
        //private bool mBusy = true;

        public ErrorList()
        {
            
        }

        public ErrorList( [FromServices] ErrorReporterService err, [FromServices] IDbContextFactory<BtDbContext> dbContextFactory)
        {

            _dbContextFactory = dbContextFactory;
            using BtDbContext _context = _dbContextFactory.CreateDbContext();
            errReport = err;

            //_context = btOnlineContextFactory.CreateDbContext();
            //ErrorLog = new C1EntityFrameworkCoreVirtualDataCollection<ErrorLog>(_context);
            try
            {
                ErrorLog = _context.ErrorLogs.ToArray();
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }


        //C1EntityFrameworkCoreVirtualDataCollection<ErrorLog> ErrorLog = null!;

        public ErrorLog[] ErrorLogs
        {
            get=> ErrorLog??= new ErrorLog[0];
        }


        
        public async Task OnGetAsync()
        {
            try
            {
                using BtDbContext _context = _dbContextFactory.CreateDbContext();
                if (_context.ErrorLogs != null)
                {
                    //ErrorLog = new C1EntityFrameworkCoreVirtualDataCollection<ErrorLog>(_context); 
                    ErrorLog = _context.ErrorLogs.ToArray();
                }
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
