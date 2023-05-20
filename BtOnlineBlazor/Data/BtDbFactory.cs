using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTOnlineBlazor.Data
{
    public class BtDbFactory : IDbContextFactory<BtDbContext>
    {
        public BtDbContext CreateDbContext()
        {
            return new BtDbContext();
        }
    }

    //public static BtDbContext GetDbContext()
    //{
    //    IDbContextFactory<BtDbContext> mContextFactory = (IDbContextFactory<BtDbContext>)Instance;
    //}
}
