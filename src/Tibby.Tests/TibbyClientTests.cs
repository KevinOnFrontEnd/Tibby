using Newtonsoft.Json.Linq;
using Xunit;
using FluentAssertions.Json;

namespace Tibby.Tests;

public class TibbyClientTests : TestBase
{
    public TibbyClientTests(TibbyTestFixture fixture) : base(fixture)
    {
    }
    
    [Fact]
    public async Task calling_router_endpoint_returns_ok()
    {
        // arrange

        // act
        var (router, _) = await TibbyClient.GetRouter();
        
        // assert
        Assert.NotNull(router);
        Assert.Equal("testnet10",router.Network);
        Assert.Equal("d037e35cc7269df10e45d0d152d2ff53d26f318adf5ea20578e5cfb80b5b2a71",router.Launcher_Id);
        Assert.Equal("2223a2a9c037ae5844f7fbf2ecfa16740e31bd2d3ffe2f4a76006e266947776f",router.Current_Id);
    }
    
    [Fact()]
    public async Task calling_tokenpairs_returns_ok()
    {
        // arrange

        // act
        var (pairs, _) = await TibbyClient.GetTokenPairs();
        
        // assert
        Assert.NotEmpty(pairs);
    }
    
    [Fact()]
    [Trait("Category","Schema")]
    public async Task router_matches_expected_schema()
    {
        // arrange

        // act
        var (_, httpResponse) = await TibbyClient.GetRouter();
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);
        
        // assert
        job.Should().HaveElement("launcher_id");
        job.Should().HaveElement("current_id");
        job.Should().HaveElement("network");
        job.Should().HaveCount(3);
    }
    
    [Fact()]
    [Trait("Category","Schema")]
    public async Task token_matches_expected_schema()
    {
        // arrange

        // act
        var (_, httpResponse) = await TibbyClient.GetTokenPairs();
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JArray.Parse(json);
        var token = job.FirstOrDefault();
        
        // assert
        job.Should().HaveCount(1);
        token.Should().HaveElement("asset_id");
        token.Should().HaveElement("pair_id");
        token.Should().HaveElement("name");
        token.Should().HaveElement("short_name");
        token.Should().HaveElement("verified");
        token.Should().HaveElement("image_url");
        token.Should().HaveCount(6);
    }
    
    [Fact()]
    [Trait("Category","Schema")]
    public async Task pairs_matches_expected_schema()
    {
        // arrange
        var (pairs, _) = await TibbyClient.GetTokenPairs();

        // act
        var (_, httpResponse) = await TibbyClient.GetToken(pairs[0].Asset_id);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);

        // assert
        job.Should().HaveElement("asset_id");
        job.Should().HaveElement("pair_id");
        job.Should().HaveElement("name");
        job.Should().HaveElement("short_name");
        job.Should().HaveElement("verified");
        job.Should().HaveElement("image_url");
        job.Should().HaveCount(6);
    }
    
    [Fact()]
    [Trait("Category","Schema")]
    public async Task quote_matches_expected_schema()
    {
        // arrange
        var (pairs, _) = await TibbyClient.GetTokenPairs();

        // act
        var (_, httpResponse) = await TibbyClient.GetQuote(pairs[0].pair_id,100);
        var json = await httpResponse.Content.ReadAsStringAsync();
        var job = JObject.Parse(json);

        // assert
        job.Should().HaveElement("amount_in");
        job.Should().HaveElement("amount_out");
        job.Should().HaveElement("price_warning");
        job.Should().HaveElement("fee");
        job.Should().HaveElement("asset_id");
        job.Should().HaveElement("input_reserve");
        job.Should().HaveElement("output_reserve");
        job.Should().HaveElement("price_impact");
        job.Should().HaveCount(8);
    }
}