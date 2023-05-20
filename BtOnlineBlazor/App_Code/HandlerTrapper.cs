using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BTOnlineBlazor.App_Code
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class HandlerTrapper
    {
        private readonly RequestDelegate _next;

        
        public string? AccountID { get; set; }

        public HandlerTrapper(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)  //, [FromQuery(Name = "AccountID")] string accountId
        {           

            string? page = httpContext.Request.Path.Value?.Replace(@"/", "");

            Console.WriteLine("Page Name is {0}, AccountID = {1}", page, AccountID);

            if(page==null || (!page.Contains(".ashx") && !page.Contains(".inf")))
                return _next(httpContext);

            AccountID = httpContext.Request.Query["AccountID"];

            

            return _next(httpContext);
        }

        private void GetRequestType(HttpContext httpContext, string page)
        {
            page = page.Replace(".ashx", "").Replace(".inf", "");

            switch (page)
            {
                case "GetAmzRefreshToken":          //Initiates the Amazon Token registration process to set up the account

                    break;

                case "AmzRefreshTokenCallback":     //Callback for the Amazon Token process to set up the account

                    break;

                case "ReRegisterComputer":          //Reregisters the computer from the user DB info.

                    break;

                case "GetImageFolder":     //Get the folder for the user's Images

                    break;

                case "GetUserIDHandler":          //Retrieve the UserID

                    break;

                case "ActivateApp":     //Activate the App

                    break;

                case "ActivateTrial":          //Activate the Trial

                    break;

                case "GetAccountTotal":     //Get the Account Total

                    break;

                case "GetAppListHandler":          //Get the list of Apps

                    break;

                case "GetAppDB":     //Get the DB of Apps for this User - may not be actively used

                    break;

                case "computer":          //Seems deprecated

                    break;

                case "CheckAppLevel":     //Get the app Level of an app

                    break;

                case "SubmitChanges":          //Submits Changes when the Blue Button is pressed

                    break;

                case "SubmitVersions":     //Used to check the installed Versions

                    break;

                case "AmazonLAPconsent":          //Initiates the Amazon Payment Workflow

                    break;

                case "AccountReview":     //Provides the User with their Account Details

                    break;

                case "GetComputerList":     //Provides the List of Computers seen on the third tab in AM

                    break;

                case "RemoveComputer":          //Removes a Computer

                    break;

                case "SubmitUserInfo":     //Used to get the User Data from the DB

                    break;

                case "AddSyncSite":          //Adds a Sync Site

                    break;

                case "AddListingSite":     //Adds a fee based site charge e.g. Amazon

                    break;

                case "RemoveListingSite":          //Removes a listing site

                    break;

                case "ConnectionRequest":     //Adds their AD ID to the Connections Console so we can easily connect using AD.

                    break;

                case "GetKey":          //Not sure this is actually used

                    break;

                case "VerifyEmail":     //Verifies a User Email is the proper address.
                    break;

                case "GetAmzKeys":          //Gets an Access Token for the current session

                    break;

                case "SetOption":     //Sets the status of Options like Get Orders 

                    break;
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class HandlerTrapperExtensions
    {
        public static IApplicationBuilder UseHandlerTrapper(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HandlerTrapper>();
        }
    }
}
