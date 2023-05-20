using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Diagnostics;
using BTOnlineBlazor.Models.Db;

namespace BTOnlineBlazor.Services
{
    //[System.Runtime.Versioning.SupportedOSPlatform("windows")]
    public class ErrorReporterService : IDisposable
    {        
        private readonly ILogger<ErrorReporterService> _logger = null!;
        //private readonly IDbContextFactory<BtDbContext> _dbContextFactory = null!;


        public ErrorReporterService( [FromServices] ILogger<ErrorReporterService> logger)   //, [FromServices] IDbContextFactory<BtDbContext> dbContextFactory
        {   
            //_dbContextFactory= dbContextFactory;
            _logger = logger;   
        }
        public ErrorReporterService()
        {           
            ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
            {
                if (Debugger.IsAttached)
                {
                    builder.AddConsole();
                    builder.AddDebug();
                }

                builder.AddEventLog();
            });
            _logger = loggerFactory.CreateLogger<ErrorReporterService>();
        }

        public void LogErr(Exception e)
        {
            //string sql = $"INSERT INTO ErrorLog (AppName, Message, InnerException, StackTrace, Source, TargetSite, Comment, FileName, TimeStamp) VALUES(";

            //sql += "'BTOnline', '" + e.Message + "', '', '" + e.StackTrace + "', '" + e.InnerException?.Message + "', '" + e.Source + "', '" + e.TargetSite?.Name + "', GetDate())";

            //using (DbConnection connection = _context.Database.GetDbConnection())
            //using (DbCommand command = connection.CreateCommand())
            //{
            //    connection.Open();
            //    command.CommandText = sql;
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
            _logger.LogError(e.Message, e.StackTrace);
            return;
            //using BtDbContext context = _dbContextFactory.CreateDbContext();

            //ErrorLog ErrLogEntry = new ErrorLog();

            //ErrLogEntry.AppName = "BTOnline";
            //ErrLogEntry.Message = e.Message;
            //ErrLogEntry.Comment = "";
            //ErrLogEntry.StackTrace = e.StackTrace;
            //if (e.InnerException != null)
            //    ErrLogEntry.InnerException = e.InnerException.Message;
            //ErrLogEntry.Source = e.Source;
            //ErrLogEntry.TargetSite = e.TargetSite?.Name;
            //ErrLogEntry.TimeStamp =  DateTime.Now;
            
            //context.ErrorLogs.Add(ErrLogEntry);

            //context.SaveChanges();

        }

        public void LogErr(string? message, Exception e, params object[] args)
        {
            int i = 0;
            foreach (object arg in args)
            {
                message = message?.Replace("{" + i + "}", arg?.ToString());

                i++;
            }
            _logger.LogInformation(message, args);
            _logger.LogError(e.Message, args);

            return;
            //using BtDbContext context = _dbContextFactory.CreateDbContext();

            //ErrorLog ErrLogEntry = new ErrorLog();

            //ErrLogEntry.AppName = "BTOnline";
            //ErrLogEntry.Message = e.Message;
            //ErrLogEntry.Comment = message;
            //ErrLogEntry.StackTrace = e.StackTrace;
            //if (e.InnerException != null)
            //    ErrLogEntry.InnerException = e.InnerException.Message;
            //ErrLogEntry.Source = e.Source;
            //ErrLogEntry.TargetSite = e.TargetSite?.Name;
            //ErrLogEntry.TimeStamp = DateTime.Now;

            //context.ErrorLogs.Add(ErrLogEntry);

            //context.SaveChanges();

        }

        public void LogMessage(string message, params object[] args)
        {

            _logger.LogInformation(message, args);

            return;
            //using BtDbContext context = _dbContextFactory.CreateDbContext();
            //int i = 0;
            //foreach (object arg in args)
            //{
            //    message = message.Replace("{" + i + "}", arg?.ToString());

            //    i++;
            //}

            //MessageLog msgLogEntry = new MessageLog();

            ////msgLogEntry.MessageId = 2530606;
            //msgLogEntry.Application = "BtOnline";
            //msgLogEntry.Message = message;
            //msgLogEntry.Application = "BTOnline";
            //msgLogEntry.TimeStamp = DateTime.Now;

            //context.MessageLogs.Add(msgLogEntry);

            //context.SaveChanges();

        }
        public void LogEventMessage(string message, params object[] args)
        {
            _logger.LogInformation(message, args);           
        }

        public void LogToConsole(string message, params object[] args)
        {
            _logger.LogInformation(message, args);           
        }

        public void Dispose()
        {
            
        }
    }
}
