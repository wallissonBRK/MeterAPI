using MeterAPI.Services;

namespace MeterAPI.Common.Extensions;

public static class AppExtensions
{
    public static WebApplication UseArchitectures(this WebApplication app)
    {
        app.UseCors();
        app.UseSwagger();
        app.UseSwaggerUI();
        //app.UseHttpsRedirection();
        app.UseMiddleware<LoggingMiddleware>();
        app.UseAuthentication();
        app.UseAuthorization();

        return app;
    }
}
