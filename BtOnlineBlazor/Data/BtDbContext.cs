using System;
using System.Collections.Generic;
using BTOnlineBlazor.App_Code;
using System.Diagnostics;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Models.Db;
using Microsoft.EntityFrameworkCore;

namespace BTOnlineBlazor.Data;

public partial class BtDbContext : DbContext
{
    public BtDbContext()
    {
    }

    public BtDbContext(DbContextOptions<BtDbContext> options)
        : base(options)
    {
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

    public virtual DbSet<AspnetPath> AspnetPaths { get; set; }

    public virtual DbSet<AspnetPersonalizationAllUser> AspnetPersonalizationAllUsers { get; set; }

    public virtual DbSet<AspnetPersonalizationPerUser> AspnetPersonalizationPerUsers { get; set; }

    public virtual DbSet<AspnetProfile> AspnetProfiles { get; set; }

    public virtual DbSet<AspnetRole> AspnetRoles { get; set; }

    public virtual DbSet<AspnetSchemaVersion> AspnetSchemaVersions { get; set; }

    public virtual DbSet<AspnetUser> AspnetUsers { get; set; }

    public virtual DbSet<AspnetWebEventEvent> AspnetWebEventEvents { get; set; }

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

    public virtual DbSet<GetExpiredAcountsForPayment> GetExpiredAcountsForPayments { get; set; }

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

    public virtual DbSet<PaymentProcessor> PaymentProcessors { get; set; }

    public virtual DbSet<RateCode> RateCodes { get; set; }

    public virtual DbSet<RemoteConnection> RemoteConnections { get; set; }

    public virtual DbSet<SiteRate> SiteRates { get; set; }

    public virtual DbSet<SubEventType> SubEventTypes { get; set; }

    public virtual DbSet<SubscribedOption> SubscribedOptions { get; set; }

    public virtual DbSet<SubscriptionEvent> SubscriptionEvents { get; set; }

    public virtual DbSet<SubscriptionRate> SubscriptionRates { get; set; }

    public virtual DbSet<SyncSite> SyncSites { get; set; }

    public virtual DbSet<UserType> UserTypes { get; set; }

    public virtual DbSet<VwAspnetApplication> VwAspnetApplications { get; set; }

    public virtual DbSet<VwAspnetMembershipUser> VwAspnetMembershipUsers { get; set; }

    public virtual DbSet<VwAspnetProfile> VwAspnetProfiles { get; set; }

    public virtual DbSet<VwAspnetRole> VwAspnetRoles { get; set; }

    public virtual DbSet<VwAspnetUser> VwAspnetUsers { get; set; }

    public virtual DbSet<VwAspnetUsersInRole> VwAspnetUsersInRoles { get; set; }

    public virtual DbSet<VwAspnetWebPartStatePath> VwAspnetWebPartStatePaths { get; set; }

    public virtual DbSet<VwAspnetWebPartStateShared> VwAspnetWebPartStateShareds { get; set; }

    public virtual DbSet<VwAspnetWebPartStateUser> VwAspnetWebPartStateUsers { get; set; }

    public virtual DbSet<WindowsVersion> WindowsVersions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https: //go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    {
        var builder = WebApplication.CreateBuilder();

        var connectionString = builder.Configuration.GetConnectionString("production");

        if (Debugger.IsAttached || Environment.MachineName.ToUpper().Equals("GECKOSERVER") || Environment.MachineName.ToUpper().Equals("WIN10DEV64"))
        {
            connectionString = builder.Configuration.GetConnectionString("development");
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                if(Debugger.IsAttached)
                {
                    builder.AddConsole();
                    builder.AddDebug();
                }
                builder.AddEventLog();
            });

            var logger = loggerFactory.CreateLogger<BtDbContext>();

            optionsBuilder.EnableSensitiveDataLogging().EnableDetailedErrors().UseSqlServer(connectionString,
                providerOptions => providerOptions.EnableRetryOnFailure()).UseLoggerFactory(loggerFactory);
        }
        else
        {
            optionsBuilder.EnableDetailedErrors().UseSqlServer(connectionString,
                providerOptions => providerOptions.EnableRetryOnFailure());
        }
        //ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Connection String Assigned: {0}", connectionString ?? "not assigned");

   
        ContextID = NextId;

        ContextInfo info = new ContextInfo(ContextID, DateTime.Now, 0, "");
        mContextState.Add(ContextID, info);
        mOpened++;
        NextId++;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.Abaa).HasColumnName("ABAA");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasColumnName("Account_Name");
            entity.Property(e => e.Active).HasDefaultValueSql("((0))");
            entity.Property(e => e.AmzCallerReference).HasMaxLength(100);
            entity.Property(e => e.AmzReferenceIndex).HasDefaultValueSql("((1))");
            entity.Property(e => e.BtpurchaseDate)
                .HasColumnType("date")
                .HasColumnName("BTPurchaseDate");
            entity.Property(e => e.BusinessName).HasMaxLength(100);
            entity.Property(e => e.Cell).HasMaxLength(50);
            entity.Property(e => e.ChargeAmount).HasColumnType("money");
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.ImageIt).HasDefaultValueSql("((1))");
            entity.Property(e => e.Ioba).HasColumnName("IOBA");
            entity.Property(e => e.NetworkServerKey).HasMaxLength(200);
            entity.Property(e => e.NextRate).HasDefaultValueSql("((1))");
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.PaymentMethod).HasDefaultValueSql("((1))");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PrimaryComputerKey).HasMaxLength(100);
            entity.Property(e => e.RateCodeLevel).HasDefaultValueSql("((0))");
            entity.Property(e => e.RateExpire).HasColumnType("date");
            entity.Property(e => e.RenewDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("User_ID");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accounts_AccountStatus");

            entity.HasOne(d => d.User).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Accounts_aspnet_Users");
        });

        modelBuilder.Entity<AccountComputerAppRateList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AccountComputerAppRateList");

            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.CurrentVersion)
                .HasMaxLength(13)
                .IsUnicode(false);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("money");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Version).HasMaxLength(15);
        });

        modelBuilder.Entity<AccountStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId);

            entity.ToTable("AccountStatus");

            entity.Property(e => e.StatusId).HasColumnName("Status_ID");
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<ActiveAppsByComputer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ActiveAppsByComputer");

            entity.Property(e => e.ActivationKey).HasMaxLength(100);
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.Folder).HasMaxLength(100);
            entity.Property(e => e.InstallName).HasMaxLength(100);
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<Address>(entity =>
        {
            entity.HasKey(e => new { e.AddressId, e.AccountId });

            entity.Property(e => e.AddressId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Address_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.Address1).HasMaxLength(100);
            entity.Property(e => e.Address2).HasMaxLength(100);
            entity.Property(e => e.Address3).HasMaxLength(100);
            entity.Property(e => e.Address4).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.PostalCode).HasMaxLength(50);
            entity.Property(e => e.State).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.Addresses)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Addresses_Accounts");
        });

        modelBuilder.Entity<AmzTransactionLog>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("AmzTransactionLog");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.AmzAuthId)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.AmzCapId)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.AuthRef).HasMaxLength(50);
            entity.Property(e => e.AuthTime).HasColumnType("date");
            entity.Property(e => e.CapRef).HasMaxLength(50);
            entity.Property(e => e.CapTime).HasColumnType("date");
            entity.Property(e => e.FinalTime).HasColumnType("date");
            entity.Property(e => e.ReasonCode).HasMaxLength(50);
            entity.Property(e => e.ReasonDescription).HasMaxLength(500);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<AppItem>(entity =>
        {
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.Folder).HasMaxLength(100);
            entity.Property(e => e.InstallName).HasMaxLength(100);
            entity.Property(e => e.TrialType).HasDefaultValueSql("((0))");
            entity.Property(e => e.Type).HasComment("0 for AppManger, 1 for BookTrakker, 2 for Discrete Level App, 3 for BitMap Level App");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.Apps)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Apps_AppTypes");
        });

        modelBuilder.Entity<AppDescription>(entity =>
        {
            entity.Property(e => e.AppDescriptionId).HasColumnName("AppDescription_ID");
            entity.Property(e => e.AppId).HasColumnName("App_ID");

            entity.HasOne(d => d.App).WithMany(p => p.AppDescriptions)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppDescriptions_Apps");

            entity.HasOne(d => d.TypeNavigation).WithMany(p => p.AppDescriptions)
                .HasForeignKey(d => d.Type)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppDescriptions_AppDescriptionTypes");
        });

        modelBuilder.Entity<AppDescriptionType>(entity =>
        {
            entity.HasKey(e => e.AppDescTypeId);

            entity.Property(e => e.AppDescTypeId).HasColumnName("AppDescType_ID");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<AppLevel>(entity =>
        {
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevel1).HasColumnName("AppLevel");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.MarginalCost).HasColumnType("money");

            entity.HasOne(d => d.App).WithMany(p => p.AppLevels)
                .HasForeignKey(d => d.AppId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AppLevels_Apps");
        });

        modelBuilder.Entity<AppLevelRate>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AppLevelRates");

            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.MarginalCost).HasColumnType("money");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<AppLevelRatesOldLocal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AppLevelRatesOldLocal");

            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Edition).HasMaxLength(50);
        });

        modelBuilder.Entity<AppType>(entity =>
        {
            entity.Property(e => e.AppTypeId).HasColumnName("AppType_ID");
            entity.Property(e => e.Type).HasMaxLength(50);
        });

        modelBuilder.Entity<AppsByComputer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AppsByComputer");

            entity.Property(e => e.ActivationKey).HasMaxLength(200);
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.ExpireDate).HasColumnType("date");
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.Folder).HasMaxLength(100);
            entity.Property(e => e.InstallName).HasMaxLength(100);
            entity.Property(e => e.Modified).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");
        });

        modelBuilder.Entity<AppsByComputerWithVersion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AppsByComputerWithVersion");

            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.ComputerName).HasMaxLength(253);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("money");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.Version).HasMaxLength(15);
        });

        modelBuilder.Entity<AppsByLevel>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AppsByLevel");

            entity.Property(e => e.AppDescription).HasMaxLength(255);
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.Folder).HasMaxLength(100);
        });

        modelBuilder.Entity<AspnetApplication>(entity =>
        {
            entity.HasKey(e => e.ApplicationId)
                .HasName("PK__aspnet_A__C93A4C98571DF1D5")
                .IsClustered(false);

            entity.ToTable("aspnet_Applications");

            entity.HasIndex(e => e.LoweredApplicationName, "UQ__aspnet_A__17477DE459FA5E80").IsUnique();

            entity.HasIndex(e => e.ApplicationName, "UQ__aspnet_A__309103315CD6CB2B").IsUnique();

            entity.HasIndex(e => e.LoweredApplicationName, "aspnet_Applications_Index").IsClustered();

            entity.Property(e => e.ApplicationId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<AspnetMembership>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_M__1788CC4D75A278F5")
                .IsClustered(false);

            entity.ToTable("aspnet_Membership");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredEmail }, "aspnet_Membership_index").IsClustered();

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.Password).HasMaxLength(128);
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).HasMaxLength(128);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetMemberships)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__Appli__778AC167");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetMembership)
                .HasForeignKey<AspnetMembership>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Me__UserI__787EE5A0");
        });

        modelBuilder.Entity<AspnetPath>(entity =>
        {
            entity.HasKey(e => e.PathId)
                .HasName("PK__aspnet_P__CD67DC582EDAF651")
                .IsClustered(false);

            entity.ToTable("aspnet_Paths");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredPath }, "aspnet_Paths_index")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.PathId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetPaths)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pa__Appli__30C33EC3");
        });

        modelBuilder.Entity<AspnetPersonalizationAllUser>(entity =>
        {
            entity.HasKey(e => e.PathId).HasName("PK__aspnet_P__CD67DC59367C1819");

            entity.ToTable("aspnet_PersonalizationAllUsers");

            entity.Property(e => e.PathId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithOne(p => p.AspnetPersonalizationAllUser)
                .HasForeignKey<AspnetPersonalizationAllUser>(d => d.PathId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pe__PathI__3864608B");
        });

        modelBuilder.Entity<AspnetPersonalizationPerUser>(entity =>
        {
            entity.HasKey(e => e.Id)
                .HasName("PK__aspnet_P__3214EC063B40CD36")
                .IsClustered(false);

            entity.ToTable("aspnet_PersonalizationPerUser");

            entity.HasIndex(e => new { e.PathId, e.UserId }, "aspnet_PersonalizationPerUser_index1")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.UserId, e.PathId }, "aspnet_PersonalizationPerUser_ncindex2").IsUnique();

            entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PageSettings).HasColumnType("image");

            entity.HasOne(d => d.Path).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.PathId)
                .HasConstraintName("FK__aspnet_Pe__PathI__3E1D39E1");

            entity.HasOne(d => d.User).WithMany(p => p.AspnetPersonalizationPerUsers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__aspnet_Pe__UserI__3F115E1A");
        });

        modelBuilder.Entity<AspnetProfile>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__aspnet_P__1788CC4C0C85DE4D");

            entity.ToTable("aspnet_Profile");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.PropertyNames).HasColumnType("ntext");
            entity.Property(e => e.PropertyValuesBinary).HasColumnType("image");
            entity.Property(e => e.PropertyValuesString).HasColumnType("ntext");

            entity.HasOne(d => d.User).WithOne(p => p.AspnetProfile)
                .HasForeignKey<AspnetProfile>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Pr__UserI__0E6E26BF");
        });

        modelBuilder.Entity<AspnetRole>(entity =>
        {
            entity.HasKey(e => e.RoleId)
                .HasName("PK__aspnet_R__8AFACE1B17F790F9")
                .IsClustered(false);

            entity.ToTable("aspnet_Roles");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredRoleName }, "aspnet_Roles_index1")
                .IsUnique()
                .IsClustered();

            entity.Property(e => e.RoleId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetRoles)
                .HasForeignKey(d => d.ApplicationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__aspnet_Ro__Appli__19DFD96B");
        });

        modelBuilder.Entity<AspnetSchemaVersion>(entity =>
        {
            entity.HasKey(e => new { e.Feature, e.CompatibleSchemaVersion }).HasName("PK__aspnet_S__5A1E6BC1693CA210");

            entity.ToTable("aspnet_SchemaVersions");

            entity.Property(e => e.Feature).HasMaxLength(128);
            entity.Property(e => e.CompatibleSchemaVersion).HasMaxLength(128);
        });

        modelBuilder.Entity<AspnetUser>(entity =>
        {
            entity.HasKey(e => e.UserId)
                .HasName("PK__aspnet_U__1788CC4D619B8048")
                .IsClustered(false);

            entity.ToTable("aspnet_Users");

            entity.HasIndex(e => new { e.ApplicationId, e.LoweredUserName }, "aspnet_Users_Index")
                .IsUnique()
                .IsClustered();

            entity.HasIndex(e => new { e.ApplicationId, e.LastActivityDate }, "aspnet_Users_Index2");

            entity.Property(e => e.UserId).HasDefaultValueSql("(newid())");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Application).WithMany(p => p.AspnetUsers)
                .HasForeignKey(d => d.ApplicationId)
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

        modelBuilder.Entity<AspnetWebEventEvent>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__aspnet_W__7944C8104F47C5E3");

            entity.ToTable("aspnet_WebEvent_Events");

            entity.Property(e => e.EventId)
                .HasMaxLength(32)
                .IsUnicode(false)
                .IsFixedLength();
            entity.Property(e => e.ApplicationPath).HasMaxLength(256);
            entity.Property(e => e.ApplicationVirtualPath).HasMaxLength(256);
            entity.Property(e => e.Details).HasColumnType("ntext");
            entity.Property(e => e.EventOccurrence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventSequence).HasColumnType("decimal(19, 0)");
            entity.Property(e => e.EventTime).HasColumnType("datetime");
            entity.Property(e => e.EventTimeUtc).HasColumnType("datetime");
            entity.Property(e => e.EventType).HasMaxLength(256);
            entity.Property(e => e.ExceptionType).HasMaxLength(256);
            entity.Property(e => e.MachineName).HasMaxLength(256);
            entity.Property(e => e.Message).HasMaxLength(1024);
            entity.Property(e => e.RequestUrl).HasMaxLength(1024);
        });

        modelBuilder.Entity<AvailableApp>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("AvailableApps");

            entity.Property(e => e.ActivationKey).HasMaxLength(100);
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.Folder).HasMaxLength(100);
        });

        modelBuilder.Entity<BookTrakkerEdition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BookTrakkerEditions");

            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.Cost).HasColumnType("money");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Edition)
                .HasMaxLength(25)
                .IsFixedLength();
            entity.Property(e => e.MarginalCost).HasColumnType("money");
        });

        modelBuilder.Entity<BtLevelByComputer>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("BtLevelByComputer");

            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
        });

        modelBuilder.Entity<CbuiLog>(entity =>
        {
            entity.HasKey(e => e.CbuiId);

            entity.ToTable("CBUI_Log");

            entity.Property(e => e.CbuiId).HasColumnName("CBUI_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.Amount).HasColumnType("money");
            entity.Property(e => e.CallerReference).HasMaxLength(50);
            entity.Property(e => e.CancelReference).HasMaxLength(50);
            entity.Property(e => e.CancelTime).HasColumnType("datetime");
            entity.Property(e => e.Status)
                .HasMaxLength(2)
                .IsFixedLength();
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TokenId)
                .HasMaxLength(100)
                .HasColumnName("TokenID");

            entity.HasOne(d => d.Account).WithMany(p => p.CbuiLogs)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK_CBUI_Log_Accounts");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.ComputerKey).HasMaxLength(200);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.RateCode).HasDefaultValueSql("((0))");
            entity.Property(e => e.SiteId).HasColumnName("Site_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.WinProdKey).HasMaxLength(50);
            entity.Property(e => e.WindowsVersion).HasMaxLength(200);

            entity.HasOne(d => d.RateCodeNavigation).WithMany(p => p.Computers)
                .HasForeignKey(d => d.RateCode)
                .HasConstraintName("FK_Computers_RateCodes");

            entity.HasOne(d => d.User).WithMany(p => p.Computers)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Computers_aspnet_Users");
        });

        modelBuilder.Entity<ComputerAppCount>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ComputerAppCount");

            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.ComputerName)
                .HasMaxLength(15)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<ComputerCost>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ComputerCost");

            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasColumnName("Account_Name");
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.ComputerKey).HasMaxLength(200);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("money");
            entity.Property(e => e.SiteId).HasColumnName("Site_ID");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.WindowsVersion).HasMaxLength(200);
        });

        modelBuilder.Entity<ComputerList>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ComputerList");

            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasColumnName("Account_Name");
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.ComputerKey).HasMaxLength(200);
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.Edition).HasMaxLength(50);
            entity.Property(e => e.Total).HasColumnType("money");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.WindowsVersion).HasMaxLength(200);
        });

        modelBuilder.Entity<ComputerSite>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ComputerSites");

            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.SiteName).HasMaxLength(50);
            entity.Property(e => e.SiteRate).HasColumnType("money");
            entity.Property(e => e.SiteType).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<ErrorLog>(entity =>
        {
            entity.HasKey(e => e.ErrorId);

            entity.ToTable("ErrorLog");

            entity.Property(e => e.ErrorId).HasColumnName("Error_ID");
            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.FileName).HasMaxLength(50);
            entity.Property(e => e.TimeStamp).HasDefaultValueSql("(getdate())");
        });

        modelBuilder.Entity<ExpiredSubscription>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("ExpiredSubscriptions");

            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<GetExpiredAcountsForPayment>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("GetExpiredAcountsForPayment");

            entity.Property(e => e.Abaa).HasColumnName("ABAA");
            entity.Property(e => e.AccountId)
                .ValueGeneratedOnAdd()
                .HasColumnName("Account_ID");
            entity.Property(e => e.AccountName)
                .HasMaxLength(50)
                .HasColumnName("Account_Name");
            entity.Property(e => e.AmzCallerReference).HasMaxLength(100);
            entity.Property(e => e.BtpurchaseDate)
                .HasColumnType("date")
                .HasColumnName("BTPurchaseDate");
            entity.Property(e => e.BusinessName).HasMaxLength(100);
            entity.Property(e => e.Cell).HasMaxLength(50);
            entity.Property(e => e.ChargeAmount).HasColumnType("money");
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.Ioba).HasColumnName("IOBA");
            entity.Property(e => e.NetworkServerKey).HasMaxLength(200);
            entity.Property(e => e.Notes).HasColumnType("ntext");
            entity.Property(e => e.Phone).HasMaxLength(50);
            entity.Property(e => e.PrimaryComputerKey).HasMaxLength(100);
            entity.Property(e => e.RateExpire).HasColumnType("date");
            entity.Property(e => e.RenewDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<ImageFolder>(entity =>
        {
            entity.Property(e => e.ImageFolderId).HasColumnName("ImageFolder_ID");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Folder).HasMaxLength(10);
            entity.Property(e => e.Timestamp)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<InstalledApp>(entity =>
        {
            entity.Property(e => e.InstalledAppId).HasColumnName("InstalledApp_ID");
            entity.Property(e => e.ActivationKey)
                .HasMaxLength(200)
                .HasDefaultValueSql("('NA')");
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.Created).HasColumnType("date");
            entity.Property(e => e.ExpireDate).HasColumnType("date");
            entity.Property(e => e.Modified).HasColumnType("date");
            entity.Property(e => e.TrialExpired).HasDefaultValueSql("((0))");
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Version).HasMaxLength(15);

            entity.HasOne(d => d.App).WithMany(p => p.InstalledApps)
                .HasForeignKey(d => d.AppId)
                .HasConstraintName("FK_InstalledApps_Apps");

            entity.HasOne(d => d.AppLevel).WithMany(p => p.InstalledApps)
                .HasForeignKey(d => d.AppLevelId)
                .HasConstraintName("FK_InstalledApps_AppLevels");

            entity.HasOne(d => d.Computer).WithMany(p => p.InstalledApps)
                .HasForeignKey(d => d.ComputerId)
                .HasConstraintName("FK_InstalledApps_Computers");
        });

        modelBuilder.Entity<InstalledAppsWithVersion>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("InstalledAppsWithVersion");

            entity.Property(e => e.AppName).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Version).HasMaxLength(15);
        });

        modelBuilder.Entity<InternetConnectionType>(entity =>
        {
            entity.HasKey(e => e.ConnectionTypeId);

            entity.Property(e => e.ConnectionTypeId).HasColumnName("ConnectionType_ID");
            entity.Property(e => e.ConnectionType)
                .HasMaxLength(20)
                .IsFixedLength();
        });

        modelBuilder.Entity<IssueTracker>(entity =>
        {
            entity.HasKey(e => e.IssueId);

            entity.ToTable("IssueTracker");

            entity.Property(e => e.IssueId).HasColumnName("Issue_ID");
            entity.Property(e => e.Date)
                .HasComputedColumnSql("(getdate())", false)
                .HasColumnType("datetime");
            entity.Property(e => e.Description).IsUnicode(false);
            entity.Property(e => e.PageLink).HasMaxLength(1000);
            entity.Property(e => e.Subject).HasMaxLength(1000);
        });

        modelBuilder.Entity<KeyNumber>(entity =>
        {
            entity.HasKey(e => e.KeyNumberVal);

            entity.Property(e => e.KeyNumberVal).HasMaxLength(15);
            entity.Property(e => e.DateStamp).HasColumnType("date");
            entity.Property(e => e.KeyType)
                .HasMaxLength(3)
                .IsFixedLength();
            entity.Property(e => e.UserId).HasColumnName("User_ID");
        });

        modelBuilder.Entity<ListingSite>(entity =>
        {
            entity.HasNoKey();

            entity.Property(e => e.Rate).HasColumnType("money");
            entity.Property(e => e.SiteKey).HasMaxLength(255);
            entity.Property(e => e.SiteName).HasMaxLength(100);
        });

        modelBuilder.Entity<ListingSiteAccount>(entity =>
        {
            entity.HasKey(e => new { e.AccountId, e.ListingSiteId });

            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.Key1)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Key2)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.RefreshToken)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Site)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.SiteId)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Message>(entity =>
        {
            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Message1).HasColumnName("Message");
            entity.Property(e => e.Subject).HasMaxLength(100);
        });

        modelBuilder.Entity<MessageLog>(entity =>
        {
            entity.HasKey(e => e.MessageId);

            entity.ToTable("MessageLog");

            entity.Property(e => e.MessageId).HasColumnName("Message_ID");
            entity.Property(e => e.Application).HasMaxLength(50);
        });

        modelBuilder.Entity<NewsMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId);

            entity.Property(e => e.MessageId).HasColumnName("MessageID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.Subject).HasMaxLength(100);
        });

        modelBuilder.Entity<Option>(entity =>
        {
            entity.Property(e => e.OptionId).HasColumnName("Option_ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rate).HasColumnType("money");
        });

        modelBuilder.Entity<PaymentLog>(entity =>
        {
            entity.HasKey(e => e.TransactionId);

            entity.ToTable("PaymentLog");

            entity.Property(e => e.TransactionId).HasColumnName("Transaction_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.AmzRequestId)
                .HasMaxLength(100)
                .HasColumnName("AmzRequest_ID");
            entity.Property(e => e.AmzTransId)
                .HasMaxLength(50)
                .HasColumnName("AmzTrans_ID");
            entity.Property(e => e.CallerReference).HasMaxLength(50);
            entity.Property(e => e.CallerRequestId)
                .HasMaxLength(50)
                .HasColumnName("CallerRequest_ID");
            entity.Property(e => e.ChargeAmount).HasColumnType("money");
            entity.Property(e => e.StatusCode).HasMaxLength(64);
            entity.Property(e => e.StatusMessage).HasMaxLength(50);
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");
            entity.Property(e => e.TransactionStatus).HasMaxLength(50);

            entity.HasOne(d => d.Account).WithMany(p => p.PaymentLogs)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PaymentLog_Accounts");
        });

        modelBuilder.Entity<PaymentProcessor>(entity =>
        {
            entity.HasKey(e => e.ProcessorId);

            entity.Property(e => e.ProcessorName).HasMaxLength(100);
        });

        modelBuilder.Entity<RateCode>(entity =>
        {
            entity.HasKey(e => e.RateCode1);

            entity.Property(e => e.RateCode1).HasColumnName("RateCode");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<RemoteConnection>(entity =>
        {
            entity.HasKey(e => e.ConnectionId);

            entity.Property(e => e.ConnectionId).HasColumnName("Connection_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.ComputerName).HasMaxLength(50);
            entity.Property(e => e.ContactName).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.RemoteId).HasMaxLength(20);
            entity.Property(e => e.TimeStamp)
                .HasComputedColumnSql("(getdate())", false)
                .HasColumnType("datetime");
        });

        modelBuilder.Entity<SiteRate>(entity =>
        {
            entity.Property(e => e.SiteRateId).HasColumnName("SiteRate_ID");
            entity.Property(e => e.SiteRate1)
                .HasColumnType("money")
                .HasColumnName("SiteRate");
            entity.Property(e => e.SiteType).HasMaxLength(20);
        });

        modelBuilder.Entity<SubEventType>(entity =>
        {
            entity.Property(e => e.SubEventTypeId).HasColumnName("SubEventType_ID");
            entity.Property(e => e.Event).HasMaxLength(50);
            entity.Property(e => e.Notes).HasMaxLength(255);
        });

        modelBuilder.Entity<SubscribedOption>(entity =>
        {
            entity.Property(e => e.SubscribedOptionId).HasColumnName("SubscribedOption_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.OptionId).HasColumnName("Option_ID");
        });

        modelBuilder.Entity<SubscriptionEvent>(entity =>
        {
            entity.Property(e => e.SubscriptionEventId).HasColumnName("SubscriptionEvent_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.ComputerId).HasColumnName("Computer_ID");
            entity.Property(e => e.Date).HasColumnType("date");
            entity.Property(e => e.SubEventTypeId).HasColumnName("SubEventType_ID");
            entity.Property(e => e.TimeStamp).HasColumnType("datetime");

            entity.HasOne(d => d.Account).WithMany(p => p.SubscriptionEvents)
                .HasForeignKey(d => d.AccountId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionEvents_Accounts");

            entity.HasOne(d => d.Computer).WithMany(p => p.SubscriptionEvents)
                .HasForeignKey(d => d.ComputerId)
                .HasConstraintName("FK_SubscriptionEvents_Computers");

            entity.HasOne(d => d.SubEventType).WithMany(p => p.SubscriptionEvents)
                .HasForeignKey(d => d.SubEventTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubscriptionEvents_SubEventTypes");
        });

        modelBuilder.Entity<SubscriptionRate>(entity =>
        {
            entity.HasKey(e => e.RateId);

            entity.Property(e => e.RateId).HasColumnName("Rate_ID");
            entity.Property(e => e.AppId).HasColumnName("App_ID");
            entity.Property(e => e.AppLevelId).HasColumnName("AppLevel_ID");
            entity.Property(e => e.Rate).HasColumnType("money");

            entity.HasOne(d => d.App).WithMany(p => p.SubscriptionRates)
                .HasForeignKey(d => d.AppId)
                .HasConstraintName("FK_SubscriptionRates_Apps");

            entity.HasOne(d => d.AppLevel).WithMany(p => p.SubscriptionRates)
                .HasForeignKey(d => d.AppLevelId)
                .HasConstraintName("FK_SubscriptionRates_AppLevels");

            entity.HasOne(d => d.RateCodeNavigation).WithMany(p => p.SubscriptionRates)
                .HasForeignKey(d => d.RateCode)
                .HasConstraintName("FK_SubscriptionRates_RateCodes");
        });

        modelBuilder.Entity<SyncSite>(entity =>
        {
            entity.HasKey(e => e.SiteId);

            entity.Property(e => e.SiteId).HasColumnName("Site_ID");
            entity.Property(e => e.AccountId).HasColumnName("Account_ID");
            entity.Property(e => e.AddressId).HasColumnName("Address_ID");
            entity.Property(e => e.SiteCode).HasMaxLength(10);
            entity.Property(e => e.SiteName).HasMaxLength(50);
            entity.Property(e => e.SiteRateId)
                .HasDefaultValueSql("((1))")
                .HasColumnName("SiteRate_ID");
        });

        modelBuilder.Entity<UserType>(entity =>
        {
            entity.Property(e => e.UserTypeId).HasColumnName("UserTypeID");
            entity.Property(e => e.Description).HasMaxLength(50);
        });

        modelBuilder.Entity<VwAspnetApplication>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Applications");

            entity.Property(e => e.ApplicationName).HasMaxLength(256);
            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredApplicationName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetMembershipUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_MembershipUsers");

            entity.Property(e => e.Comment).HasColumnType("ntext");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.FailedPasswordAnswerAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.FailedPasswordAttemptWindowStart).HasColumnType("datetime");
            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LastLockoutDate).HasColumnType("datetime");
            entity.Property(e => e.LastLoginDate).HasColumnType("datetime");
            entity.Property(e => e.LastPasswordChangedDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredEmail).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.MobilePin)
                .HasMaxLength(16)
                .HasColumnName("MobilePIN");
            entity.Property(e => e.PasswordAnswer).HasMaxLength(128);
            entity.Property(e => e.PasswordQuestion).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetProfile>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Profiles");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Roles");

            entity.Property(e => e.Description).HasMaxLength(256);
            entity.Property(e => e.LoweredRoleName).HasMaxLength(256);
            entity.Property(e => e.RoleName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_Users");

            entity.Property(e => e.LastActivityDate).HasColumnType("datetime");
            entity.Property(e => e.LoweredUserName).HasMaxLength(256);
            entity.Property(e => e.MobileAlias).HasMaxLength(16);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetUsersInRole>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_UsersInRoles");
        });

        modelBuilder.Entity<VwAspnetWebPartStatePath>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Paths");

            entity.Property(e => e.LoweredPath).HasMaxLength(256);
            entity.Property(e => e.Path).HasMaxLength(256);
        });

        modelBuilder.Entity<VwAspnetWebPartStateShared>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_Shared");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<VwAspnetWebPartStateUser>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vw_aspnet_WebPartState_User");

            entity.Property(e => e.LastUpdatedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<WindowsVersion>(entity =>
        {
            entity.HasKey(e => e.WinVersionId);

            entity.Property(e => e.WinVersionId)
                .HasMaxLength(10)
                .HasColumnName("WinVersion_ID");
            entity.Property(e => e.Version).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
