using BlazorDownloadFile;
using BTOnlineBlazor.Services;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.JSInterop;
using BlazorDownloadFile;

namespace BTOnlineBlazor.App_Code
{
    public static partial class ServiceInitializer
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            
            services.AddTransient<ErrorReporterService>();
            services.AddTransient<EventLogManagerService>();
            services.AddTransient<AccountUtilitiesService>();
            return services;
        }

        private static void RegisterCustomDependencies(IServiceCollection services)
        {
            //services.AddTransient<GetAmzKeysService>();
        }

        ///// <summary>
        ///// Registers blazor download file service
        ///// </summary>
        ///// <param name="services"></param>
        ///// <param name="lifetime"></param>
        ///// <returns></returns>
        //public static IServiceCollection AddBlazorDownloadFile(this IServiceCollection services, ServiceLifetime lifetime = ServiceLifetime.Scoped)
        //{
        //    return ServiceCollectionDescriptorExtensions.Add(services,
        //        new ServiceDescriptor(typeof(IBlazorDownloadFileService),
        //        sp => new BlazorDownloadFileService(sp.GetRequiredService<IJSRuntime>()),
        //        lifetime));
        //}
    }
}
