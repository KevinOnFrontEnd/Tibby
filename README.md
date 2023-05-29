# Tibby
Simple HttpClient for interacting with TibetSwap.io API, a port of the client that was created in https://github.com/KevinOnFrontEnd/SwapHunter

Usage:
```C#
.ConfigureServices((hostContext, services) =>
{
  var tibetSwapOptions = hostContext.Configuration.GetSection("TibetSwap").Get<TibetSwapOptions>();
  services.AddTibbyClient(tibetSwapOptions);
 }
```
