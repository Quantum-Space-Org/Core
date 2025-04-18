using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Quantum.Core;

namespace Quantum.ProductInfo;

public static class ProductInfoMiddleware
{
    public static async Task UseProductInfo(this IApplicationBuilder app)
    {
        app.Use(async (context, next) =>
        {
            var requestedUri = Microsoft.AspNetCore.Http.Extensions.UriHelper.GetEncodedUrl(context.Request);

            if (context.Request.Method.ToUpper() == "GET" && requestedUri.EndsWith("productinfo"))
            {
                var productVersion = ProductVersion.GetProductInfo();

                context.Response.StatusCode = 200;

                context.Response.ContentType = "application/json";

                var jsonString = productVersion.Serialize();

                await context.Response.WriteAsync(jsonString, Encoding.UTF8);
            }
            else
            {
                await next();
            }
        });
    }
}