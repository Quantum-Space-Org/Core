using Microsoft.Extensions.Primitives;

namespace Quantum.CorrelationId;

public static class HttpContextAccessorExtensions
{
    public static string GetCorrelationId(this IHttpContextAccessor contextAccessor)
    {
        var doesHeaderExist = contextAccessor.HttpContext?.Request.Headers.TryGetValue(
            Constants.CorrelationIdHeaderTitle,
            out StringValues value) ?? false;

        return doesHeaderExist ? value : string.Empty;
    }
}