using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using BTOnlineBlazor.App_Code;
using BTOnlineBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BTOnlineBlazor.Data;

public partial class AppManagerContext : DbContext
{
    public AppManagerContext()
    {
    }

    public AppManagerContext(DbContextOptions<AppManagerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountComputerAppRateList> AccountComputerAppRateLists { get; set; }

    public virtual DbSet<AccountStatus> AccountStatuses { get; set; }

    public virtual DbSet<ActiveAppsByComputer> ActiveAppsByComputers { get; set; }

   
   
    public virtual DbSet<AppItem> Apps { get; set; }

    public virtual DbSet<AppDescription> AppDescriptions { get; set; }

    public virtual DbSet<AppDescriptionType> AppDescriptionTypes { get; set; }

    public virtual DbSet<AppLevel> AppLevels { get; set; }

    public virtual DbSet<AppLevelRate> AppLevelRates { get; set; }

    public virtual DbSet<AppType> AppTypes { get; set; }

    public virtual DbSet<AppsByComputer> AppsByComputers { get; set; }

    public virtual DbSet<AppsByComputerWithVersion> AppsByComputerWithVersions { get; set; }

    public virtual DbSet<AppsByLevel> AppsByLevels { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

      public virtual DbSet<AvailableApp> AvailableApps { get; set; }

    public virtual DbSet<BookTrakkerEdition> BookTrakkerEditions { get; set; }

    public virtual DbSet<BtLevelByComputer> BtLevelByComputers { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<ComputerAppCount> ComputerAppCounts { get; set; }

    public virtual DbSet<ComputerCost> ComputerCosts { get; set; }

    public virtual DbSet<ComputerList> ComputerLists { get; set; }

    public virtual DbSet<InstalledApp> InstalledApps { get; set; }

    public virtual DbSet<InstalledAppsWithVersion> InstalledAppsWithVersions { get; set; }

    public virtual DbSet<ListingSite> ListingSites { get; set; }

    public virtual DbSet<ListingSiteAccount> ListingSiteAccounts { get; set; }

    public virtual DbSet<NewsMessage> NewsMessages { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<RateCode> RateCodes { get; set; }

    public virtual DbSet<SiteRate> SiteRates { get; set; }

    public virtual DbSet<SubEventType> SubEventTypes { get; set; }

    public virtual DbSet<SubscribedOption> SubscribedOptions { get; set; }

    public virtual DbSet<SubscriptionEvent> SubscriptionEvents { get; set; }

    public virtual DbSet<SubscriptionRate> SubscriptionRates { get; set; }

    public virtual DbSet<SyncSite> SyncSites { get; set; }

    public virtual DbSet<WindowsVersion> WindowsVersions { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=GECKOSERVER\\GECKOSERVER;Initial Catalog=booktrak_booktrakker;Persist Security Info=True;User ID=BT_Mgr;Password=Stimpasaurus64#4;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {       

        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.Active).HasDefaultValueSql("((0))");
            entity.Property(e => e.AmzReferenceIndex).HasDefaultValueSql("((1))");
            entity.Property(e => e.ImageIt).HasDefaultValueSql("((1))");
            entity.Property(e => e.NextRate).HasDefaultValueSql("((1))");
            entity.Property(e => e.PaymentMethod).HasDefaultValueSql("((1))");
            entity.Property(e => e.RateCodeLevel).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Accounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accounts_AccountStatus");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accounts_aspnet_Users");
        });

        modelBuilder.Entity<AccountComputerAppRateList>(entity =>
        {
            entity.ToView("AccountComputerAppRateList");
        });

        modelBuilder.Entity<ActiveAppsByComputer>(entity =>
        {
            entity.ToView("ActiveAppsByComputer");
        });

       

        modelBuilder.Entity<AppItem>(entity =>
        {
            entity.Property(e => e.TrialType).HasDefaultValueSql("((0))");
            entity.Property(e => e.Type).HasComment("0 for AppManger, 1 for BookTrakker, 2 for Discrete Level App, 3 for BitMap Level App");
            
            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Apps)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apps_AppTypes");
        });

        modelBuilder.Entity<AppDescription>(entity =>
        {
            entity.HasOne(d => d.App).WithMany(p => p.AppDescriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppDescriptions_Apps");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.AppDescriptions)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppDescriptions_AppDescriptionTypes");
        });

        modelBuilder.Entity<AppLevel>(entity =>
        {
            entity.HasOne(d => d.App).WithMany(p => p.AppLevels)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppLevels_Apps");
        });

        modelBuilder.Entity<AppLevelRate>(entity =>
        {
            entity.ToView("AppLevelRates");
        });

       
        modelBuilder.Entity<AppsByComputer>(entity =>
        {
            entity.ToView("AppsByComputer");
        });

        modelBuilder.Entity<AppsByComputerWithVersion>(entity =>
        {
            entity.ToView("AppsByComputerWithVersion");
        });

        modelBuilder.Entity<AppsByLevel>(entity =>
        {
            entity.ToView("AppsByLevel");
        });

        
        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.Property(e => e.LastActivityDate).HasConversion(e => e, e => new DateTime(e.Ticks, DateTimeKind.Utc));
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_U__1788CC4D619B8048")
                .IsClustered(false);

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Us__Appli__6383C8BA");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspnetUsersInRole",
                    r => r.HasOne<AspnetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__RoleI__208CD6FA"),
                    l => l.HasOne<AspnetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__aspnet_Us__UserI__1F98B2C1"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK__aspnet_U__AF2760AD1DB06A4F");
                        j.ToTable("aspnet_UsersInRoles");
                        j.HasIndex(new[] { "RoleId" }, "aspnet_UsersInRoles_index");
                    });
        });

 
        modelBuilder.Entity<AvailableApp>(entity =>
        {
            entity.ToView("AvailableApps");
        });

        modelBuilder.Entity<BookTrakkerEdition>(entity =>
        {
            entity.ToView("BookTrakkerEditions");

            entity.Property(e => e.Description).IsFixedLength();
            entity.Property(e => e.Edition).IsFixedLength();
        });

        modelBuilder.Entity<BtLevelByComputer>(entity =>
        {
            entity.ToView("BtLevelByComputer");
        });

 
        modelBuilder.Entity<Computer>(entity =>
        {
            entity.Property(e => e.RateCode).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.RateCodeNavigation).WithMany(p => p.Computers).HasConstraintName("FK_Computers_RateCodes");

            entity.HasOne(d => d.User).WithMany(p => p.Computers)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Computers_aspnet_Users");
        });

        modelBuilder.Entity<ComputerAppCount>(entity =>
        {
            entity.ToView("ComputerAppCount");

            entity.Property(e => e.ComputerName).IsFixedLength();
        });

        modelBuilder.Entity<ComputerList>(entity =>
        {
            entity.ToView("ComputerList");
        });


        modelBuilder.Entity<InstalledApp>(entity =>
        {
            entity.Property(e => e.ActivationKey).HasDefaultValueSql("('NA')");
            entity.Property(e => e.TrialExpired).HasDefaultValueSql("((0))");

            entity.HasOne(d => d.App).WithMany(p => p.InstalledApps).HasConstraintName("FK_InstalledApps_Apps");

            entity.HasOne(d => d.AppLevel).WithMany(p => p.InstalledApps).HasConstraintName("FK_InstalledApps_AppLevels");

            entity.HasOne(d => d.Computer).WithMany(p => p.InstalledApps).HasConstraintName("FK_InstalledApps_Computers");
        });

        modelBuilder.Entity<InstalledAppsWithVersion>(entity =>
        {
            entity.ToView("InstalledAppsWithVersion");
        });

        modelBuilder.Entity<SubscriptionEvent>(entity =>
        {
            entity.HasOne(d => d.Account).WithMany(p => p.SubscriptionEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionEvents_Accounts");

            entity.HasOne(d => d.Computer).WithMany(p => p.SubscriptionEvents).HasConstraintName("FK_SubscriptionEvents_Computers");

            entity.HasOne(d => d.SubEventType).WithMany(p => p.SubscriptionEvents)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionEvents_SubEventTypes");
        });

        modelBuilder.Entity<SubscriptionRate>(entity =>
        {
            entity.HasOne(d => d.App).WithMany(p => p.SubscriptionRates).HasConstraintName("FK_SubscriptionRates_Apps");

            entity.HasOne(d => d.AppLevel).WithMany(p => p.SubscriptionRates).HasConstraintName("FK_SubscriptionRates_AppLevels");

            entity.HasOne(d => d.RateCodeNavigation).WithMany(p => p.SubscriptionRates).HasConstraintName("FK_SubscriptionRates_RateCodes");
        }); 

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
