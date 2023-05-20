using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models;
using BTOnlineBlazor.Models.Db;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BTOnlineBlazor.Services
{
    public class EventLogManagerService :IDisposable
    {                
        private readonly ErrorReporterService errReport;
        private readonly IDbContextFactory<BtDbContext> _dbContextFactory;
        public EventLogManagerService( [FromServices] ErrorReporterService err, [FromServices] IDbContextFactory<BtDbContext> dbContextFactory)
        {           
            errReport = err;
            _dbContextFactory = dbContextFactory;
        }

        public void AddSubEvent(int? EventID, int? AccountID, int? ComputerID, int? AppID, int? AppLevel)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();

                SubscriptionEvent SubEvent = new SubscriptionEvent
                {
                    AccountId = AccountID ?? 0,
                    ComputerId = ComputerID,
                    SubEventTypeId = EventID ?? 0,
                    AppId = AppID,
                    AppLevelId = AppLevel,
                    Date = DateTime.Now

                };

                context.SubscriptionEvents.Add(SubEvent);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }

        public void AddSubEvent(int EventID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();

                SubscriptionEvent SubEvent = new SubscriptionEvent
                {
                    AccountId = 0,
                    ComputerId = null,
                    SubEventTypeId = EventID,
                    AppId = null,
                    AppLevelId = null,
                    Date = DateTime.Now
                    //TimeStamp = DateTime.Now

                };

                context.SubscriptionEvents.Add(SubEvent);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }


        public void AddSubEvent(int EventID, int AccountID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                SubscriptionEvent SubEvent = new SubscriptionEvent
                {
                    AccountId = AccountID,
                    ComputerId = null,
                    SubEventTypeId = EventID,
                    AppId = null,
                    AppLevelId = null,
                    Date = DateTime.Now
                    //TimeStamp = DateTime.Now

                };

                context.SubscriptionEvents.Add(SubEvent);
                context.SaveChanges();
                //errReport.LogMessage("Event " + EventID + " Recorded for Account " + AccountID);
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }

        public void AddSubEvent(int EventID, int? AccountID, int? ComputerID, int? AppID, int? AppLevel, DateTime? date)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();

                SubscriptionEvent SubEvent = new SubscriptionEvent
                {
                    AccountId = (int) AccountID,
                    ComputerId = ComputerID,
                    SubEventTypeId = (int)EventID,
                    AppId = AppID,
                    AppLevelId = AppLevel,
                    Date = (DateTime)date

                };

                context.SubscriptionEvents.Add(SubEvent);
                context.SaveChanges();

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }

        public int GetSubEventID(string EventName)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                SubEventType? SubEvent = context.SubEventTypes.SingleOrDefault(a => a.Event.Equals(EventName));
                if (SubEvent != null)
                    return SubEvent.SubEventTypeId;
                else
                    return -1;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return -1;
            }
        }

        public SubscriptionEvent? GetSubEventByName(string EventName, int AppID, int? ComputerID, int AccountID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                int EventTypeID = GetSubEventID(EventName);

                SubscriptionEvent? SubEvent = context.SubscriptionEvents.SingleOrDefault(a => a.SubEventTypeId.Equals(EventTypeID) && a.AccountId.Equals(AccountID)
                                             && a.ComputerId.Equals(ComputerID) && a.AppId.Equals(AppID));

                return SubEvent;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return null;
            }
        }

        public void Dispose()
        {
            
        }
    }
}
