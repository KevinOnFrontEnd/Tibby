# Tibby
Simple HttpClient for interacting with TibetSwap.io API, a port of the client that was created in https://github.com/KevinOnFrontEnd/SwapHunter

# Setup
```C#
.ConfigureServices((hostContext, services) =>
{
  var tibetSwapOptions = hostContext.Configuration.GetSection("TibetSwap").Get<TibetSwapOptions>();
  services.AddTibbyClient(tibetSwapOptions);
  services.Configure<TibetSwapOptions>(hostContext.Configuration.GetSection("TibetSwap"));
 }
```

Add configuration to appsettings.json

TibetSwap Mainnet
```
  "TibetSwap": {
    "ApiEndPoint": "https://api.v2.tibetswap.io",
    "TokensEndpoint": "/tokens",
    "TokenPairEndpoint": "/pair",
    "QuoteEndpoint": "/quote",
    "RouterEndpoint": "/router",
    "TokenEndpoint": "/token",
    "OfferEndpoint": "/offer",
    "TibetDevFeeWalletAddress" :  "txch1hm6sk2ktgx3u527kp803ex2lten3xzl2tpjvrnc0affvx5upd6mqnn6lxh"
  }
```

TibetSwap Testnet10
```JSON
  "TibetSwap": {
    "ApiEndPoint": "https://api.v2-testnet10.tibetswap.io",
    "TokensEndpoint": "/tokens",
    "TokenPairEndpoint": "/pair",
    "QuoteEndpoint": "/quote",
    "RouterEndpoint": "/router",
    "TokenEndpoint": "/token",
    "OfferEndpoint": "/offer",
    "TibetDevFeeWalletAddress" :  "txch1hm6sk2ktgx3u527kp803ex2lten3xzl2tpjvrnc0affvx5upd6mqnn6lxh"
  }
```

# Usage
Inject ITibbyClient into required class.



