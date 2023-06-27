using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Tibby.Models;

namespace Tibby;

public class TibbyClient : ITibbyClient
{
    private IOptions<TibetSwapOptions> _options;
    private HttpClient _client { get; set; }
    private ILogger<TibbyClient> _logger { get; set; }
    
    public TibbyClient(IOptions<TibetSwapOptions> options, HttpClient httpClient, ILogger<TibbyClient> logger) 
    { 
      _options = options;
      _client = httpClient;
      _logger = logger;
    }

    public async Task<(TokenPairResponse,HttpResponseMessage)> GetPair(string pair)
    {
      _logger.LogInformation($"Requesting pair {pair}");
      var response = await _client.GetAsync($"{_options.Value.TokenPairEndpoint}/{pair}");
      string responseBody = await response.Content.ReadAsStringAsync();
      _logger.LogInformation(responseBody);
      var item = JsonConvert.DeserializeObject<TokenPairResponse>(responseBody);
      return (item, response);
    }

    public async Task<(QuoteResponse, HttpResponseMessage)> GetQuote(string pair, double amount_in, bool xch_is_input = true, bool estimate_fee = true)
    {
      _logger?.LogInformation($"Requesting Quote for {pair}, amount_in {amount_in}");
      var response = await _client.GetAsync($"{_options.Value.QuoteEndpoint}/{pair}?amount_in={amount_in}&xch_is_input={xch_is_input}&estimate_fee={estimate_fee}");
      string responseBody = await response.Content.ReadAsStringAsync();
      _logger?.LogInformation($"Quote response: {responseBody}");
      var quote = JsonConvert.DeserializeObject<QuoteResponse>(responseBody);
      return (quote, response);
    }

    public async Task<(OfferResponse, HttpResponseMessage)> PostOffer(string pairId, string offer, double donationAmount, string[] donationAddresses, string[] donationWeights)
    {
      var postedOffer = new
      {
        offer = offer,
        action = "SWAP",
        total_donation_amount = (int) Math.Floor(donationAmount),
        donation_addresses= donationAddresses,
        donation_weights = donationWeights
      };
      
      var json = JsonConvert.SerializeObject(postedOffer);
      _logger?.LogInformation($"Posting offer: {json}");
      var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
      content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
      var response = await _client.PostAsync($"{_options.Value.OfferEndpoint}/{pairId}", content);
      string responseBody = await response.Content.ReadAsStringAsync();
      _logger?.LogInformation($"Offer response: {responseBody}");
      var swap = JsonConvert.DeserializeObject<OfferResponse>(responseBody);
      return (swap, response);
    }

    public async Task<(RouterResponse, HttpResponseMessage)> GetRouter()
    {
      var response = await _client.GetAsync($"{_options.Value.RouterEndpoint}");
      string responseBody = await response.Content.ReadAsStringAsync();
      _logger?.LogInformation($"Router response: {responseBody}");
      var router = JsonConvert.DeserializeObject<RouterResponse>(responseBody);
      return (router, response);
    }

    public async Task<(TokenResponse, HttpResponseMessage)> GetToken(string assetId)
    {
      var response = await _client.GetAsync($"{_options.Value.TokenEndpoint}/{assetId}");
      string responseBody = await response.Content.ReadAsStringAsync();
      _logger?.LogInformation($"Token response: {responseBody}");
      var token = JsonConvert.DeserializeObject<TokenResponse>(responseBody);
      return (token, response);
    }

    public async Task<(List<TokenResponse>, HttpResponseMessage)> GetTokenPairs()
    {
      var response = await _client.GetAsync(_options.Value.TokensEndpoint);
      string responseBody = await response.Content.ReadAsStringAsync();
      _logger?.LogInformation($"Token pairs: {responseBody}");
      List<TokenResponse> pairs = JsonConvert.DeserializeObject<List<TokenResponse>>(responseBody);
      return (pairs, response);
    }
}