using BTOnlineBlazor.App_Code;
using BTOnlineBlazor.Services;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BTOnlineBlazor.Data
{
    public class BtDbContextFactory : IDbContextFactory<BtDbContext>
    {
        private static readonly Lazy<BtDbContextFactory> lazy = new Lazy<BtDbContextFactory>(() => new BtDbContextFactory());
        private readonly ILogger<BtDbContextFactory> mLogger;

        private Dictionary<int, ContextInfo> mContextState = new Dictionary<int, ContextInfo>();

        private double mMaxLifeSpan = 0;
        public static BtDbContextFactory Instance
        {
            get
            {
                return lazy.Value;
            }
        }

        public Dictionary<int, ContextInfo> ContextState { get => mContextState; set => mContextState = value; }

        //private ErrorReporterService errReport = ErrorReporterFactory.Instance.CreateErrorReporter();
        //private IDbContextFactory<BtDbContext> mContextFactory = null!;
        private DbContextOptions<BtDbContext> dbOptions = null!;
        private string? _dbConnectionString = string.Empty;
        private int mHitCount = 0;

        private int mOpened = 0;
        private int mDisposed = 0;
        public BtDbContextFactory()
        {

            try
            {
                ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
                {
                    builder.AddConsole();
                    builder.AddDebug();
                    builder.AddEventLog();
                });

                mLogger = loggerFactory.CreateLogger<BtDbContextFactory>();

                var builder = WebApplication.CreateBuilder();

                _dbConnectionString = builder?.Configuration.GetConnectionString("production");

                if (Debugger.IsAttached || Environment.MachineName.ToUpper().Equals("GECKOSERVER"))
                    _dbConnectionString = builder?.Configuration.GetConnectionString("development");

                ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Connection String: {0}", _dbConnectionString ?? "not assigned");

                System.Console.WriteLine(_dbConnectionString);
                var optionsBuilder = new DbContextOptionsBuilder<BtDbContext>();
                optionsBuilder.UseSqlServer(_dbConnectionString,
                providerOptions => providerOptions.EnableRetryOnFailure());
                optionsBuilder.EnableDetailedErrors();
                optionsBuilder.EnableSensitiveDataLogging();
                dbOptions = optionsBuilder.Options;

                //mContextFactory = (IDbContextFactory<BtDbContext>)Instance;
            }
            catch (Exception ex)
            {
                //errReport.LogErr(ex);
            }

        }

        //public BtDbContext CreateContext()
        //{
        //    //if(mContextFactory == null)
        //    //{
        //    //    mContextFactory = (IDbContextFactory<BtDbContext>)Instance;
        //    //}
        //    BtDbContext context = ((IDbContextFactory<BtDbContext>)Instance).CreateDbContext();
        //    return context;
        //}

        public BtDbContext CreateContext()
        {
            mHitCount++;
            //mLogger.LogInformation("Context Count:{0}", mHitCount.ToString());
            BtDbContext context = new BtDbContext(dbOptions);//_dbConnectionString
            context.ContextID = mHitCount;
            ContextInfo info = new ContextInfo(mHitCount, DateTime.Now, 0, "");
            mContextState.Add(mHitCount, info);
            context.ContextDisposed += Context_ContextDisposed;
            mOpened++;
            return context;
        }

        private void Context_ContextDisposed(object? sender, EventArgs e)
        {
            BtDbContext context = (BtDbContext)sender;
            DateTime creationTime = mContextState[context.ContextID].ClosedTime;
            mContextState[context.ContextID].ClosedTime = DateTime.Now;
            var lifetime = (mContextState[context.ContextID].ClosedTime - creationTime).TotalMilliseconds;
            mContextState[context.ContextID].LifeSpan = lifetime;
            if (lifetime > mMaxLifeSpan)
                mMaxLifeSpan = lifetime;
            mDisposed++;
            mLogger.LogInformation(new EventId(1111, "DbContextDisposed"), "Max Lifespan: {0}, Opened: {1}, Disposed: {2}", mMaxLifeSpan, mOpened, mDisposed);
        }

        public BtDbContext CreateDbContext()
        {
            throw new NotImplementedException();
        }
    }

    public class ContextInfo
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public DateTime ClosedTime { get; set; }

        public double LifeSpan { get; set; }

        public ContextInfo(int id, DateTime closedTime, double lifeTime, string name)
        {
            Name = name;
            Id = id;
            ClosedTime = closedTime;
            LifeSpan = lifeTime;
        }
    }
}
