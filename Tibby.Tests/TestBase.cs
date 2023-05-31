using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Tibby.Extensions;
using Tibby.Models;
using Xunit;

namespace Tibby.Tests;

[Collection("Integration")]
public class TestBase : IClassFixture<TibbyTestFixture>
{
    public TibbyTestFixture Fixture { get; }
    public ITibbyClient TibbyClient =>  TestHost.Services.GetService<ITibbyClient>();
    public IHost TestHost { get; }
    
    public TestBase(TibbyTestFixture fixture)
    {
        Fixture = fixture;
        TestHost = CreateHostBuilder().Build();
        Task.Run(() =>
        { 
            return TestHost.StartAsync();
        });
    }
    
    public IHostBuilder? CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder().ConfigureWebHostDefaults(b =>
        {
            b.ConfigureAppConfiguration((hostContext, configurationBuilder) =>
            {
                configurationBuilder.SetBasePath(Directory.GetCurrentDirectory());
                configurationBuilder.AddJsonFile("testingappsettings.json", optional: false);
            });
            
            
        }).ConfigureWebHost(host =>
        {
             host.ConfigureServices((hostContext, services) =>
            {
                services.Configure<TibetSwapOptions>(hostContext.Configuration.GetSection("TibetSwap"));
                services.AddTibbyClient();
                services.Configure<TibetSwapOptions>(hostContext.Configuration.GetSection("TibetSwap"));
            });
        });
    }
    
    public void Dispose()
    {
        Task.Run(() => TestHost.StopAsync());
    }
}