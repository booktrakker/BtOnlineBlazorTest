using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Models.Db;

namespace BTOnlineBlazor.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ErrorLog> ErrorLog { get; set; } = default!;
    }
}