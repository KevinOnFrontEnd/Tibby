using Xunit;

namespace Tibby.Tests;

[CollectionDefinition("Integration")]
public class IntegrationCollection : ICollectionFixture<TibbyTestFixture>
{
    
}