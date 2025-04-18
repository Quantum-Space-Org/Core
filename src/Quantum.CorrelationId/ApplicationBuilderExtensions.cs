using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;

namespace Quantum.CorrelationId;

public static class ApplicationBuilderExtensions
{
    public static void UserCorrelationId(this IApplicationBuilder app)
        => UserCorrelationId(app, string.Empty, string.Empty);

    public static void UserCorrelationId(this IApplicationBuilder app, string appName, string instanceName)
    {
        app.Use(async (context, next) =>
        {
            var correlationId = Id(appName, instanceName);

            SetCorrelationIdOnHeader(context, correlationId);

            context.Response.OnStarting(() =>
            {
                context.Response.Headers.Add(Constants.CorrelationIdHeaderTitle, correlationId);
                return Task.FromResult(0);
            });

            await next();
        });
    }

    private static void SetCorrelationIdOnHeader(HttpContext context, StringValues correlationId)
        => context.Request.Headers.Add(Constants.CorrelationIdHeaderTitle, correlationId);

    private static StringValues Id(string appName, string instanceName)
        => string.IsNullOrWhiteSpace(appName) &&
           string.IsNullOrWhiteSpace(instanceName)
            ? $"{Guid.NewGuid().ToString()}"
            : $"{appName}-{instanceName}-{Guid.NewGuid().ToString()}";
}