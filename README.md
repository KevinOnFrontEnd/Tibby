# Tibby
Simple HttpClient for interacting with TibetSwap.io API documented at https://api.v2.tibetswap.io/docs#/default, a port of the client that was created in https://github.com/KevinOnFrontEnd/SwapHunter


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

### TibetSwap Mainnet
```JSON
  "TibetSwap": {
    "ApiEndPoint": "https://api.v2.tibetswap.io",
    "TokensEndpoint": "/tokens",
    "TokenPairEndpoint": "/pair",
    "QuoteEndpoint": "/quote",
    "RouterEndpoint": "/router",
    "TokenEndpoint": "/token",
    "OfferEndpoint": "/offer",
  }
```

### TibetSwap Testnet10
```JSON
  "TibetSwap": {
    "ApiEndPoint": "https://api.v2-testnet10.tibetswap.io",
    "TokensEndpoint": "/tokens",
    "TokenPairEndpoint": "/pair",
    "QuoteEndpoint": "/quote",
    "RouterEndpoint": "/router",
    "TokenEndpoint": "/token",
    "OfferEndpoint": "/offer",
  }
```

# Usage
Inject ITibbyClient into required class.

# Methods
- GetPair(string pair).  **/**
- GetQuote(string pair, double amount_in, bool xch_is_input = true, bool estimate_fee = true).  **/quote/{pair}**
- PostOffer(string pairId, string offer, double donationAmount, string[] donationAddresses, string[] donationWeights). - **/offer/{pair}**
- GetRouter() - **/router**
- GetToken(string assetId). - **/toke/{assetId}**
- GetTokenPairs(). - **/Pairs**
   


