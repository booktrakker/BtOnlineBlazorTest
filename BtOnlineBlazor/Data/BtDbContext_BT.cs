using BTOnlineBlazor.App_Code;
using BTOnlineBlazor.Services;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection;

namespace BTOnlineBlazor.Data
{
    public partial class BtDbContext : DbContext
    {
        public static int NextId = 0;
        private static int mOpened = 0;
        private static int mDisposed = 0;
        private static double mMaxLifeSpan = 0;
        private Dictionary<int, ContextInfo> mContextState = new Dictionary<int, ContextInfo>();

        public int ContextID { get; set; }
        public event EventHandler<EventArgs> ContextDisposed;
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

        public override void Dispose()
        {
            //ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Disposed Context {0}", ContextID);
            DateTime creationTime = mContextState[ContextID].ClosedTime;
            mContextState[ContextID].ClosedTime = DateTime.Now;
            var lifetime = (mContextState[ContextID].ClosedTime - creationTime).TotalMilliseconds;
            mContextState[ContextID].LifeSpan = lifetime;
            if (lifetime > mMaxLifeSpan)
                mMaxLifeSpan = lifetime;
            mDisposed++;
            //if (Debugger.IsAttached || Environment.MachineName.ToUpper().Equals("GECKOSERVER"))
            //    ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Disposed Current ID: {0}, Max Lifespan: {1}, Opened: {2}, Disposed: {3}", ContextID, mMaxLifeSpan, mOpened, mDisposed);
            using ErrorReporterService errReport = new ErrorReporterService();

            errReport.LogEventMessage("Disposed Current ID: {0}, Max Lifespan: {1}, Opened: {2}, Disposed: {3}", ContextID, mMaxLifeSpan, mOpened, mDisposed);

            errReport.Dispose();

            base.Dispose();
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
