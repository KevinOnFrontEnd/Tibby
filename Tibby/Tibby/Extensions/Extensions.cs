using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Tibby.Models;

namespace Tibby.Extensions;

public static class Extensions
{
    public static void AddTibbyClient(this IServiceCollection services, TibetSwapOptions tibetSwapOptions)
    {
        if (tibetSwapOptions == null)
            throw new ArgumentException("TibetSwap Configuration section missing!");
        if (string.IsNullOrEmpty(tibetSwapOptions?.ApiEndpoint))
            throw new ArgumentException("TibetSwap.ApiEndpoint not defined");
        
        services.AddHttpClient<ITibbyClient, TibbyClient>(c =>
        {
            c.BaseAddress = new System.Uri(tibetSwapOptions.ApiEndpoint);
        });
    }
}