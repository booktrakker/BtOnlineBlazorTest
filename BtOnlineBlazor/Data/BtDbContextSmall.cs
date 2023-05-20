using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Reflection;
using BTOnlineBlazor.App_Code;
using BTOnlineBlazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BTOnlineBlazor.Data;

public partial class BtDbContext : DbContext
{
    public int ContextId { get; set; }
    public event EventHandler<EventArgs> ContextDisposed;
    public BtDbContext()
    {
    }

    public BtDbContext(DbContextOptions<BtDbContext> options)
        : base(options)
    {
       
    }


    public bool? IsDisposed()
    {
        bool? result = true;
        var typeDbContext = typeof(DbContext);
        var isDisposedTypeField = typeDbContext.GetField("_disposed", BindingFlags.NonPublic | BindingFlags.Instance);

        if (isDisposedTypeField != null)
        {
            result = (bool?)isDisposedTypeField.GetValue(this);
        }

        return result;
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<AccountComputerAppRateList> AccountComputerAppRateLists { get; set; }

    public virtual DbSet<AccountStatus> AccountStatuses { get; set; }

    public virtual DbSet<ActiveAppsByComputer> ActiveAppsByComputers { get; set; }

    public virtual DbSet<Address> Addresses { get; set; }

    public virtual DbSet<AmzTransactionLog> AmzTransactionLogs { get; set; }

    public virtual DbSet<AppItem> Apps { get; set; }

    public virtual DbSet<AppDescription> AppDescriptions { get; set; }

    public virtual DbSet<AppDescriptionType> AppDescriptionTypes { get; set; }

    public virtual DbSet<AppLevel> AppLevels { get; set; }

    public virtual DbSet<AppLevelRate> AppLevelRates { get; set; }

    public virtual DbSet<AppLevelRatesOldLocal> AppLevelRatesOldLocals { get; set; }

    public virtual DbSet<AppType> AppTypes { get; set; }

    public virtual DbSet<AppsByComputer> AppsByComputers { get; set; }

    public virtual DbSet<AppsByComputerWithVersion> AppsByComputerWithVersions { get; set; }

    public virtual DbSet<AppsByLevel> AppsByLevels { get; set; }

    public virtual DbSet<AspnetApplication> AspnetApplications { get; set; }

    public virtual DbSet<AspnetMembership> AspnetMemberships { get; set; }

    //public virtual DbSet<AspnetPath> AspnetPaths { get; set; }

    //public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

    //public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

    //public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

    //public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

    //public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

    //public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

    public virtual DbSet<AvailableApp> AvailableApps { get; set; }

    public virtual DbSet<BookTrakkerEdition> BookTrakkerEditions { get; set; }

    public virtual DbSet<BtLevelByComputer> BtLevelByComputers { get; set; }

    public virtual DbSet<CbuiLog> CbuiLogs { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<ComputerAppCount> ComputerAppCounts { get; set; }

    public virtual DbSet<ComputerCost> ComputerCosts { get; set; }

    public virtual DbSet<ComputerList> ComputerLists { get; set; }

    public virtual DbSet<ComputerSite> ComputerSites { get; set; }

    public virtual DbSet<ErrorLog> ErrorLogs { get; set; }

    public virtual DbSet<ExpiredSubscription> ExpiredSubscriptions { get; set; }

    public virtual DbSet<ImageFolder> ImageFolders { get; set; }

    public virtual DbSet<InstalledApp> InstalledApps { get; set; }

    public virtual DbSet<InstalledAppsWithVersion> InstalledAppsWithVersions { get; set; }

    public virtual DbSet<InternetConnectionType> InternetConnectionTypes { get; set; }

    public virtual DbSet<IssueTracker> IssueTrackers { get; set; }

    public virtual DbSet<KeyNumber> KeyNumbers { get; set; }

    public virtual DbSet<ListingSite> ListingSites { get; set; }

    public virtual DbSet<ListingSiteAccount> ListingSiteAccounts { get; set; }

    public virtual DbSet<Message> Messages { get; set; }

    public virtual DbSet<MessageLog> MessageLogs { get; set; }

    public virtual DbSet<NewsMessage> NewsMessages { get; set; }

    public virtual DbSet<Option> Options { get; set; }

    public virtual DbSet<PaymentLog> PaymentLogs { get; set; }

    public virtual DbSet<RateCode> RateCodes { get; set; }

    public virtual DbSet<RemoteConnection> RemoteConnections { get; set; }

    public virtual DbSet<SiteRate> SiteRates { get; set; }

    public virtual DbSet<SubEventType> SubEventTypes { get; set; }

    public virtual DbSet<SubscribedOption> SubscribedOptions { get; set; }

    public virtual DbSet<SubscriptionEvent> SubscriptionEvents { get; set; }

    public virtual DbSet<SubscriptionRate> SubscriptionRates { get; set; }

    public virtual DbSet<SyncSite> SyncSites { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    //public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

    //public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

    //public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

    //public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

    //public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

    //public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

    //public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

    //public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

    //public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

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

        modelBuilder.Entity<Address>(entity =>
        {
            entity.Property(e => e.AddressId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Account).WithMany(p => p.Addresses)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Accounts");
        });

        modelBuilder.Entity<AmzTransactionLog>(entity =>
        {
            entity.Property(e => e.AmzAuthId).IsFixedLength();
            entity.Property(e => e.AmzCapId).IsFixedLength();
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

        modelBuilder.Entity<AppLevelRatesOldLocal>(entity =>
        {
            entity.ToView("AppLevelRatesOldLocal");
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

        //modelBuilder.Entity<AspnetApplication>(entity =>
        //{
        //    entity.HasKey(e => e.ApplicationId)
        //        .HasName("PK__aspnet_A__C93A4C98571DF1D5")
        //        .IsClustered(false);

        //    entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index").IsClustered();

        //    entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
        //});

        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_M__1788CC4D75A278F5")
                .IsClustered(false);

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index").IsClustered();

            entity.Property(e => e.UserId).ValueGeneratedNever();

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__778AC167");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__787EE5A0");
        });

        //modelBuilder.Entity<AspnetPath>(entity =>
        //{
        //    entity.HasKey(e => e.PathId)
        //        .HasName("PK__aspnet_P__CD67DC582EDAF651")
        //        .IsClustered(false);

        //    entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
        //        .IsUnique()
        //        .IsClustered();

        //    entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");

        //    entity.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__aspnet_Pa__Appli__30C33EC3");
        //});

        //modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
        //{
        //    entity.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC59367C1819");

        //    entity.Property(e => e.PathId).ValueGeneratedNever();

        //    entity.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__aspnet_Pe__PathI__3864608B");
        //});

        //modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
        //{
        //    entity.HasKey(e => e.Id)
        //        .HasName("PK__aspnet_P__3214EC063B40CD36")
        //        .IsClustered(false);

        //    entity.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
        //        .IsUnique()
        //        .IsClustered();

        //    entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

        //    entity.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers).HasConstraintName("FK__aspnet_Pe__PathI__3E1D39E1");

        //    entity.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers).HasConstraintName("FK__aspnet_Pe__UserI__3F115E1A");
        //});

        //modelBuilder.Entity<AspnetProfile>(entity =>
        //{
        //    entity.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4C0C85DE4D");

        //    entity.Property(e => e.UserId).ValueGeneratedNever();

        //    entity.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__aspnet_Pr__UserI__0E6E26BF");
        //});

        //modelBuilder.Entity<AspnetRole>(entity =>
        //{
        //    entity.HasKey(e => e.RoleId)
        //        .HasName("PK__aspnet_R__8AFACE1B17F790F9")
        //        .IsClustered(false);

        //    entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
        //        .IsUnique()
        //        .IsClustered();

        //    entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");

        //    entity.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
        //        .OnDelete(DeleteBehavior.ClientSetNull)
        //        .HasConstraintName("FK__aspnet_Ro__Appli__19DFD96B");
        //});

        //modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        //{
        //    entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC1693CA210");
        //});

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

        //modelBuilder.Entity<AspnetWebEventEvent>(entity =>
        //{
        //    entity.HasKey(e => e.EventId).HasName("PK__aspnet_W__7944C8104F47C5E3");

        //    entity.Property(e => e.EventId).IsFixedLength();
        //});

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

        modelBuilder.Entity<CbuiLog>(entity =>
        {
            entity.Property(e => e.Status).IsFixedLength();

            entity.HasOne(d => d.Account).WithMany(p => p.CbuiLogs).HasConstraintName("FK_CBUI_Log_Accounts");
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

        modelBuilder.Entity<ComputerCost>(entity =>
        {
            entity.ToView("ComputerCost");
        });

        modelBuilder.Entity<ComputerList>(entity =>
        {
            entity.ToView("ComputerList");
        });

        modelBuilder.Entity<ComputerSite>(entity =>
        {
            entity.ToView("ComputerSites");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.Property(e => e.TimeStamp).HasConversion(e=>e, e=> new DateTime(e.Ticks, DateTimeKind.Utc));
            //entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ExpiredSubscription>(entity =>
        {
            entity.ToView("ExpiredSubscriptions");
        });

        modelBuilder.Entity<ImageFolder>(entity =>
        {
            entity.Property(e => e.Timestamp).HasDefaultValueSql("(getdate())");
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

        modelBuilder.Entity<InternetConnectionType>(entity =>
        {
            entity.Property(e => e.ConnectionType).IsFixedLength();
        });

        modelBuilder.Entity<IssueTracker>(entity =>
        {
            entity.Property(e => e.Date).HasComputedColumnSql("(getdate())", false);
        });

        modelBuilder.Entity<KeyNumber>(entity =>
        {
            entity.Property(e => e.KeyType).IsFixedLength();
        });

        modelBuilder.Entity<PaymentLog>(entity =>
        {
            entity.HasOne(d => d.Account).WithMany(p => p.PaymentLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentLog_Accounts");
        });

        modelBuilder.Entity<RemoteConnection>(entity =>
        {
            entity.Property(e => e.TimeStamp).HasComputedColumnSql("(getdate())", false);
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

        modelBuilder.Entity<SyncSite>(entity =>
        {
            entity.Property(e => e.SiteRateId).HasDefaultValueSql("((1))");
        });

        //modelBuilder.Entity<VwAspnetApplication>(entity =>
        //{
        //    entity.ToView("vw_aspnet_Applications");
        //});

        //modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
        //{
        //    entity.ToView("vw_aspnet_MembershipUsers");
        //});

        //modelBuilder.Entity<VwAspnetProfile>(entity =>
        //{
        //    entity.ToView("vw_aspnet_Profiles");
        //});

        //modelBuilder.Entity<VwAspnetRole>(entity =>
        //{
        //    entity.ToView("vw_aspnet_Roles");
        //});

        //modelBuilder.Entity<VwAspnetUser>(entity =>
        //{
        //    entity.ToView("vw_aspnet_Users");
        //});

        //modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
        //{
        //    entity.ToView("vw_aspnet_UsersInRoles");
        //});

        //modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
        //{
        //    entity.ToView("vw_aspnet_WebPartState_Paths");
        //});

        //modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
        //{
        //    entity.ToView("vw_aspnet_WebPartState_Shared");
        //});

        //modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
        //{
        //    entity.ToView("vw_aspnet_WebPartState_User");
        //});

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    public override void Dispose()
    {
        ContextDisposed?.Invoke(this, EventArgs.Empty);
        ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("BtDbContext Disposed: {0}", ContextId);
        base.Dispose();
    }
}
