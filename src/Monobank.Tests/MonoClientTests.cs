using System.Threading.Tasks;
using Monobank.Core;
using NUnit.Framework;

namespace Monobank.Tests
{
    [TestFixture]
    public class MonoClientTests
    {
        private MonoClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new MonoClient();
        }

        [Test]
        public void InstanceCreated()
        {
            Assert.IsNotNull(_client);
        }

        [Test]
        public async Task GetCurrencies()
        {
            var currencies = await _client.Currency.GetCurrencies();
        }
    }
}