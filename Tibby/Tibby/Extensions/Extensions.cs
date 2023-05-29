using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Tibby.Models;

namespace Tibby.Extensions;

public static class Extensions
{
    public static void AddTibbyClient(this IServiceCollection services, IOptions<TibetSwapOptions> tibetSwapOptions)
    {
        if (tibetSwapOptions?.Value == null)
            throw new ArgumentException("TibetSwap Configuration section missing!");
        
        services.AddHttpClient<ITibbyClient, TibbyClient>(c =>
        {
            c.BaseAddress = new System.Uri(tibetSwapOptions.Value.ApiEndpoint);
        });
    }
}