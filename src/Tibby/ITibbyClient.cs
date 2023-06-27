using Tibby.Models;
namespace Tibby;

public interface ITibbyClient
{
    /// <summary>
    /// Returns list of all token pairs.
    /// </summary>
    /// <returns></returns>
    Task<(List<TokenResponse>, HttpResponseMessage)> GetTokenPairs();
    
    /// <summary>
    /// Returns a token pair 
    /// </summary>
    /// <param name="pair"></param>
    /// <returns></returns>
    Task<(TokenPairResponse,HttpResponseMessage)> GetPair(string pair);
    
    /// <summary>
    /// returns a quote for a token pair
    /// </summary>
    /// <param name="pair"></param>
    /// <param name="amount_in"></param>
    /// <param name="xch_is_input"></param>
    /// <param name="estimate_fee"></param>
    /// <returns></returns>
    Task<(QuoteResponse, HttpResponseMessage)> GetQuote(string pair, double amount_in, bool xch_is_input = true, bool estimate_fee = true);
    
    /// <summary>
    /// Posts a generated chia offer for a token pair.
    /// </summary>
    /// <param name="pairId"></param>
    /// <param name="offer">Chia offer file as a string</param>
    /// <param name="donationAmount">Donation amount</param>
    /// <param name="donationAddresses">Addresses that split donation Fee</param>
    /// <param name="donationWeights">Weight Distribution of donations/param>
    /// <returns></returns>
    Task<(OfferResponse, HttpResponseMessage)> PostOffer(string pairId, string offer, double donationAmount, string[] donationAddresses, string[] donationWeights);
    
    /// <summary>
    /// Returns Router
    /// </summary>
    /// <returns></returns>
    Task<(RouterResponse, HttpResponseMessage)> GetRouter();
    
    /// <summary>
    /// Returns token for a given assetId
    /// </summary>
    /// <param name="assetId"></param>
    /// <returns></returns>
    Task<(TokenResponse, HttpResponseMessage)> GetToken(string assetId);
}