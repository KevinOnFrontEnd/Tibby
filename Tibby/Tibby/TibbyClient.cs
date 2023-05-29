using Tibby.Models;

namespace Tibby;

public class TibbyClient : ITibbyClient
{
    public Task<List<TokenResponse>> GetTokenPairs()
    {
        throw new NotImplementedException();
    }

    public Task<TokenPairResponse> GetPair(string pair)
    {
        throw new NotImplementedException();
    }

    public Task<QuoteResponse> GetQuote(string pair, double amount_in, bool xch_is_input = true, bool estimate_fee = true)
    {
        throw new NotImplementedException();
    }

    public Task<OfferResponse> PostOffer(string pairId, string offer, double donationAmount, string action = "SWAP")
    {
        throw new NotImplementedException();
    }

    public Task<RouterResponse> GetRouter()
    {
        throw new NotImplementedException();
    }

    public Task<TokenResponse> GetToken(string assetId)
    {
        throw new NotImplementedException();
    }
}