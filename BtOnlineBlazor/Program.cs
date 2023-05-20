using BTOnlineBlazor.Areas.Identity;
using BTOnlineBlazor.Data;
using BTOnlineBlazor.App_Code;
//using BTOnlineBlazor.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Http.Connections;




var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var connectionString = builder.Configuration.GetConnectionString("production");

if (Debugger.IsAttached || Environment.MachineName.ToUpper().Equals("GECKOSERVER") || Environment.MachineName.ToUpper().Equals("WIN10DEV64"))
    connectionString = builder.Configuration.GetConnectionString("development");

ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Connection String Assigned: {0}", connectionString ?? "not assigned");

//builder.Services.AddDbContext<BtDbContext>(options =>
//    options.UseSqlServer(connectionString,
//    providerOptions => providerOptions.EnableRetryOnFailure()),
//    optionsLifetime: ServiceLifetime.Transient);

//builder.Services.AddDbContextPool<BtDbContext>(
//   options => options.UseSqlServer(connectionString,
//       providerOptions => providerOptions.EnableRetryOnFailure()));


//builder.Services.AddDbContext<AppManagerContext>(options =>
//    options.UseSqlServer(connectionString), optionsLifetime: ServiceLifetime.Singleton);


builder.Services.AddDbContextFactory<BtDbContext>(options => options.UseSqlServer(connectionString));

ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("DBContextFactory Connection String: {0}", connectionString ?? "not assigned");

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<BtDbContext>();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<IdentityUser>>();
//builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddHttpClient();
builder.Services.RegisterApplicationServices();
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.MaxDepth = 256;
    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
    options.JsonSerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.DefaultBufferSize = 200000000;
});

builder.Services.AddServerSideBlazor().AddHubOptions(options =>
{
    // maximum message size of 2MB
    options.MaximumReceiveMessageSize = 2000000;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//var provider = new FileExtensionContentTypeProvider();
//provider.Mappings[".ashx"] = "text/html";

//app.UseStaticFiles(new StaticFileOptions { ContentTypeProvider = provider });


RewriteOptions urlOptions = new RewriteOptions().AddRewrite(@"^(.*).ashx$", "api/$1", true);

urlOptions.AddRewrite(@"^(.*).inf$", "api/ComputerInfo", true);

urlOptions.AddRewrite(@"AmazonLAPconsent.aspx", "AmazonLAPconsent", false);

urlOptions.AddRewrite(@"AccountReview.aspx", "AccountReview", false);

urlOptions.AddRewrite(@"IpnHandler.aspx", "api/IpnHandler", false);

urlOptions.AddRewrite(@"^(.*).aspx$", "api/$1", true);

app.UseRewriter(urlOptions);

//app.UseHandlerTrapper();
app.UseStaticFiles();


app.UseHttpsRedirection();

app.UseRouting();

if (Debugger.IsAttached || Environment.MachineName.ToUpper().Equals("GECKOSERVER"))
{
    app.Use(next => context =>
    {
        ErrorReporterFactory.Instance.CreateErrorReporter().LogToConsole($"Found: {context.GetEndpoint()?.DisplayName}");
        return next(context);
    });

}
else
{
    ErrorReporterFactory.Instance.CreateErrorReporter().LogEventMessage("Connection String: {0}", connectionString ?? "not assigned");
}
app.UseAuthorization();

app.MapControllers();
//app.MapBlazorHub();
app.MapBlazorHub(configureOptions: options =>
{
    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
});

app.MapFallbackToPage("/_Host");

// setup app's root folders
AppDomain.CurrentDomain.SetData("ContentRootPath", app.Environment.ContentRootPath);
AppDomain.CurrentDomain.SetData("WebRootPath", app.Environment.WebRootPath);

//app.WaitForShutdown();
app.Run();


