using Xunit;

namespace Tibby.Tests;

public class TibbyClientTests : TestBase
{
    public TibbyClientTests(TibbyTestFixture fixture) : base(fixture)
    {
    }
    
    [Fact(Skip = "TibetSwap Testnet10 api is down")]
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
    
    [Fact(Skip = "TibetSwap Testnet10 api is down")]
    public async Task calling_tokenpairs_returns_ok()
    {
        // arrange

        // act
        var (pairs, _) = await TibbyClient.GetTokenPairs();
        
        // assert
        Assert.NotEmpty(pairs);
    }
}