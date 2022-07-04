using CleanAssetApi.API.CustomExceptionMiddleware;

namespace CleanAssetApi.API.Extension
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureCustomExceptionMiddleware(this WebApplication app)
        {
            app.UseMiddleware<ExceptionMiddleware>();
            app.ConfigureCustomExceptionMiddleware();
        }
    }
}
