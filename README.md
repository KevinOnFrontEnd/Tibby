# Tibby
Simple HttpClient for interacting with TibetSwap.io API

Usage:
```C#
                .ConfigureServices((hostContext, services) =>
                {
                    var tibetSwapOptions = hostContext.Configuration.GetSection("TibetSwap").Get<TibetSwapOptions>();
                    services.AddTibbyClient(tibetSwapOptions);
                }
```
