# Tibby
Simple HttpClient for interacting with TibetSwap.io API documented at https://api.v2.tibetswap.io/docs#/default, a port of the client that was created in https://github.com/KevinOnFrontEnd/SwapHunter


# Setup
```C#
{
    services.Configure<TibetSwapOptions>(hostContext.Configuration.GetSection("TibetSwap"));
    services.AddTibbyClient();
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
- Import Tibby.Models
- Inject ITibbyClient into required class.

# Methods
- GetPair(string pair).  **/**
- GetQuote(string pair, double amount_in, bool xch_is_input = true, bool estimate_fee = true).  **/quote/{pair}**
- PostOffer(string pairId, string offer, double donationAmount, string[] donationAddresses, string[] donationWeights). - **/offer/{pair}**
- GetRouter() - **/router**
- GetToken(string assetId). - **/toke/{assetId}**
- GetTokenPairs(). - **/Pairs**

# Helper Methods
The following methods are useful when accepting an offer on TibetSwap (e.g. posting to offers endpoint).

ConvertToMojos - Converts from XCH to Mojos
GetInputPrice - Returns the amount of tokens your xch would return taking into account the  Liquidity fee of 0.7%.
getOutputPrice - Returns the amount of xch amount that is required to get your desired token amount taking into account the liquidity fee of 0.7%.

   


