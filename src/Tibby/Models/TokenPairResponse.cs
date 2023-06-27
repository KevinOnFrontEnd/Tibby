namespace Tibby.Models
{
  public class TokenPairResponse
  {
    public string launcher_id { get; set; }
    public string asset_id { get; set; }
    public string liquidity_asset_id { get; set; }
    public string xch_reserve { get; set; }
    public string token_reserve { get; set; }
    public string liquidity { get; set; }
    public string last_coin_id_on_chain { get; set; }
  }
}