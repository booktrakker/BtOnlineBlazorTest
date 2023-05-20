using BTOnlineBlazor.App_Code;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.Models.Db;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace BTOnlineBlazor.Services
{
    public class AccountUtilitiesService : IDisposable
    {
        private readonly ErrorReporterService errReport;
        private readonly IDbContextFactory<BtDbContext> _dbContextFactory;
        
        public const string cNoAccount = "NoAccount";
        public AccountUtilitiesService(ErrorReporterService errReport, IDbContextFactory<BtDbContext> dbContextFactory)
        {
            this.errReport = errReport;
            _dbContextFactory = dbContextFactory;
            
        }


        public  Account? GetAccount(AspnetUser? user)
        {
            try
            {
                if (user is not null)
                {
                    using BtDbContext context = _dbContextFactory.CreateDbContext();

                    Account? account;

                    account = context.Accounts.SingleOrDefault(c => c.UserId.Equals(user.UserId));

                    return account;
                }
                else
                {
                    errReport.LogMessage("Null User passed in call to Utility.GetAccount(aspnet_User user)");
                }
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);

            }
            return null;
        }

        public Account? GetAccount(Guid? userID)
        {

            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(c => c.UserId.Equals(userID));
                return account;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return null;
            }
        }

        public  string GetAccountID(string? email)
        {

            string UserID = cNoAccount;
            try
            {

                Account? account = GetAccountByEmail(email);

                //KeyNumber key = BT_Data.KeyNumbers.SingleOrDefault(k => k.KeyNumberVal == email);
                if (account is not null)
                {
                    UserID = account.UserId.ToString();
                }

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
            return UserID;
        }

        public  int? GetAccountID(Guid? UserID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(a => a.UserId.Equals(UserID));
                return account?.AccountId;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return -1;
            }
        }

        public Account? GetAccount(int? AccountID)
        {
            try
            {
                //errReport.LogMessage("Getting Account {0}", AccountID);
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(c => c.AccountId.Equals(AccountID));
                return account;

            }
            catch (Exception ex)
            {
                errReport.LogErr("Account ID: {0}", ex, AccountID);
                return null;
            }
        }

        public Account? GetAccount(string? accountID)
        {
            try
            {
                //errReport.LogMessage("Getting Account {0}", AccountID);


                if (accountID == null)
                    return null;
                Account? account = null;

                Guid accountId = new Guid();
                bool result = Guid.TryParse(accountID, out accountId);

                using BtDbContext context = _dbContextFactory.CreateDbContext();

                if (result)
                {
                    account = context.Accounts.FirstOrDefault(c => c.UserId.Equals(accountId));
                    //context.Dispose();

                }
                else if (accountID.IsNumeric())
                {
                    int Id = accountID.ConvertTo<int>();
                    account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(Id));
                }
                else if (!accountID.Contains("@"))
                {
                    accountID = Crypto.DecryptUrlField(accountID);

                    if (accountID.Contains("-"))
                    {
                        result = Guid.TryParse(accountID, out accountId);
                        if (result)
                        {
                            account = context.Accounts.FirstOrDefault(c => c.UserId.Equals(accountId));
                        }
                    }
                    else
                        account = context.Accounts.FirstOrDefault(c => c.AccountName.Equals(accountID));
                }
                //context.Dispose();
                return account;

            }
            catch (Exception ex)
            {
                errReport.LogErr("Account ID: {0}", ex, accountID ?? "ID Not Found");
                return null;
            }
        }

        //public Account? GetAccount(string? accountID, BtDbContext context)
        //{
        //    try
        //    {
        //        //errReport.LogMessage("Getting Account {0}", AccountID);
                

        //        if (accountID == null)
        //            return null;
        //        Account? account = null;

        //        Guid accountId = new Guid();
        //        bool result = Guid.TryParse(accountID, out accountId);

        //        //using BtDbContext context = _dbContextFactory.CreateDbContext();

        //        if (result)
        //        {
        //            account = context.Accounts.FirstOrDefault(c => c.UserId.Equals(accountId));
        //            //context.Dispose();

        //        }
        //        else if (accountID.IsNumeric())
        //        {
        //            int Id = accountID.ConvertTo<int>();
        //            account = context.Accounts.SingleOrDefault(a => a.AccountId.Equals(Id));
        //        }
        //        else if (!accountID.Contains("@"))
        //        {
        //            accountID = Crypto.DecryptUrlField(accountID);

        //            if (accountID.Contains("-"))
        //            {
        //                result = Guid.TryParse(accountID, out accountId);
        //                if (result)
        //                {
        //                    account = context.Accounts.FirstOrDefault(c => c.UserId.Equals(accountId));
        //                }
        //            }
        //            else
        //                account = context.Accounts.FirstOrDefault(c => c.AccountName.Equals(accountID));
        //        }
        //        //context.Dispose();
        //        return account;

        //    }
        //    catch (Exception ex)
        //    {
        //        errReport.LogErr("Account ID: {0}", ex, accountID ?? "ID Not Found");
        //        return null;
        //    }
        //}
        

        public  Account? GetAccountByEmail(string? Email)
        {
            try
            {
                Account? account = null;
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                AspnetMembership? Member = context.AspnetMemberships.SingleOrDefault(a => a.Email.Equals(Email));
                if (Member is not null)
                    account = context.Accounts.SingleOrDefault(c => c.UserId.Equals(Member.UserId));

                return account;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return null;
            }
        }

        public  decimal? GetOptionsTotal(int accountId)
        {
            decimal? result = 0;
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                var options = context.SubscribedOptions.Where(c => c.AccountId.Equals(accountId));

                if (options.Any())
                {
                    foreach (var option in options)
                    {
                        result += GetOptionRate(option.OptionId);
                    }
                }
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return result;
        }

        public  decimal? GetOptionRate(int option)
        {
            decimal? result = 0;
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Option? optionRate = context.Options.FirstOrDefault(s => s.OptionId.Equals(option));

                result = optionRate?.Rate;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return result;
        }

        public  decimal? GetComputerCosts(Account account)
        {
            decimal? total = 0;
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                var Total =
                    from A in context.ComputerCosts
                    where A.UserId.Equals(account.UserId)

                    select A;

                total = Total.Sum(s => s.Rate);
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return total;
        }

        public AspnetUser? GetUserByID(Guid UserID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                AspnetUser? user = context.AspnetUsers.SingleOrDefault(u => u.UserId.Equals(UserID));
                return user;

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return null;
            }
        }

        public AspnetUser? GetUser(string? userID)
        {
            try
            {
                AspnetUser? user = null;

                Guid userId = Guid.Empty;

                if (userID == null)
                {
                    return user;
                }
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                if (userID.Contains("@"))
                {
                    Account? account = GetAccountByEmail(userID);
                    if (account is not null)
                    {
                        user = context.AspnetUsers.SingleOrDefault(u => u.UserId.Equals(account.UserId));
                    }
                }
                else
                {
                    if (Guid.TryParse(userID, out userId))
                    {
                        user = context.AspnetUsers.SingleOrDefault(u => u.UserId.Equals(userId));
                    }
                    else
                    {
                        userID = Crypto.DecryptUrlField(userID);

                        if (userID.Contains("@"))
                        {
                            Account? account = GetAccountByEmail(userID);
                            if (account is not null)
                            {
                                user = context.AspnetUsers.SingleOrDefault(u => u.UserId.Equals(account.UserId));
                            }
                        }
                        else
                        {
                            Guid.TryParse(userID, out userId);
                            user = context.AspnetUsers.FirstOrDefault(u => u.UserId.Equals(userId));
                        }
                    }
                }

                return user;

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return null;
            }
        }

        public DateTime? GetRenewDate(AspnetUser? user)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                if (user == null)
                {
                    return new DateTime(2000, 1, 1);
                }
                Account? account = context.Accounts.SingleOrDefault(c => c.UserId.Equals(user.UserId));

                if (account != null)
                {
                    return (DateTime)account.RenewDate;
                    //return new DateTime(SubEvent.Date.Year, SubEvent.Date.Month, SubEvent.Date.Day);
                }
                else
                    return new DateTime(2000, 1, 1);

            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return new DateTime(2000, 1, 1);
            }
        }


        public DateTime? GetRenewDate(int? accountId)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(c => c.AccountId.Equals(accountId));

                if (account is not null)
                {
                    return account.RenewDate;
                    //return new DateTime(SubEvent.Date.Year, SubEvent.Date.Month, SubEvent.Date.Day);
                }
                else
                    return new DateTime(2000, 1, 1);
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
                return new DateTime(2000, 1, 1);
            }
        }

        public void SetRenewDateToday(Guid UserID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(c => c.UserId.Equals(UserID));
                account.RenewDate = DateTime.Now;
                context.SaveChanges();
                errReport.LogMessage("Utility.SetRenewDate: Updated Renew Date for accountId " + account.AccountId + " New Date = " + account.RenewDate);
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }

        public void SetInitialRenewDate(int AccountID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(c => c.AccountId.Equals(AccountID));
                if (account.RenewDate.Value.ToShortDateString() == DateTime.Parse("1/1/2000").ToShortDateString())
                {
                    account.RenewDate = DateTime.Now.AddMonths(1);
                    context.SaveChanges();
                    //errReport.LogMessage("Utility.SetInitialRenewDate: Set Initial Renew Date for accountId " + account.Account_ID + "; Renew Date set to: " + account.RenewDate.ToString());
                }
                else
                {
                    errReport.LogMessage("Utility.SetInitialRenewDate: Set Initial Renew Date for accountId " + account.AccountId + "; Failed, Renew Date was already set: " + account.RenewDate.ToString());
                }

            }
            catch (Exception ex)
            {
                errReport.LogErr("SetInitialRenewDate Failed", ex);
            }
        }

        public void SetRenewDate(int AccountID)
        {
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Account? account = context.Accounts.SingleOrDefault(c => c.AccountId.Equals(AccountID));
                account.RenewDate = DateTime.Now.AddMonths(1);
                context.SaveChanges();
                errReport.LogMessage("Utility.SetRenewDate: Updated Renew Date for accountId " + account.AccountId);


            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }
        }

        public string? GetOptionName(int option)
        {
            string? result = "";
            try
            {
                using BtDbContext context = _dbContextFactory.CreateDbContext();
                Option? optionName = context.Options.FirstOrDefault(s => s.OptionId.Equals(option));

                result = optionName?.Name;
            }
            catch (Exception ex)
            {
                errReport.LogErr(ex);
            }

            return result;
        }
        public Guid GetUserIdAsGuid(string accountId)
        {
            Guid userId = Guid.Empty;

            if (!Guid.TryParse(accountId, out userId))
            {
                accountId = Crypto.DecryptUrlField(accountId);
                Guid.TryParse(accountId, out userId);
            }

            return userId;
        }


        //public Account? GetAccount(string? accountID)
        //{
        //    try
        //    {
        //        //errReport.LogMessage("Getting Account {0}", AccountID);


        //        if (accountID == null)
        //            return null;
        //        Account? account;

        //        using BtDbContext context = _dbContextFactory.CreateDbContext();

        //        if (accountID.Contains("-"))
        //        {
        //            Guid accountId = new Guid();
        //            bool result = Guid.TryParse(accountID, out accountId);
        //            if (result)
        //            {
        //                account = context.Accounts.FirstOrDefault(c => c.UserId.Equals(accountId));
        //                context.Dispose();
        //                return account;
        //            }
        //        }

        //        if (!accountID.Contains("@"))
        //            accountID = Crypto.DecryptUrlField(accountID);

        //        if (accountID.Contains("-"))
        //        {
        //            Guid accountId = new Guid();
        //            bool result = Guid.TryParse(accountID, out accountId);
        //            if (result)
        //            {
        //                account = context.Accounts.FirstOrDefault(c => c.UserId.Equals(accountId));
        //                context.Dispose();
        //                return account;
        //            }
        //        }

        //        account = context.Accounts.FirstOrDefault(c => c.AccountName.Equals(accountID));
        //        context.Dispose();
        //        return account;

        //    }
        //    catch (Exception ex)
        //    {
        //        errReport.LogErr("Account ID: {0}", ex, accountID ?? "ID Not Found");
        //        return null;
        //    }
        //}
        public void Dispose()
        {
            
        }
    }
}
