using CleanAssetApi.Application.Interfaces;
using CleanAssetApi.Application.Services;

namespace CleanAssetApi.API
{
    public static class ServiceExtension
    {
        public static void ConfigureLoggerService(this IServiceCollection services)
        {
            services.AddSingleton<ILoggerManager, LoggerManagerService>();
        }
    }
}
