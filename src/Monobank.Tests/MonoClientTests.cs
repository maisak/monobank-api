using Monobank.Core;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Monobank.Tests
{
    [TestFixture]
    public class MonoClientTests
    {
        private MonoClient _client;

        [SetUp]
        public void Setup()
        {
            _client = new MonoClient("");
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

        [Test]
        public async Task GetClientInfo()
        {
            var client = await _client.Client.GetClientInfo();
        }

        [Test]
        public async Task GetClientStatement()
        {
            var statements = await _client.Client.GetStatements(new DateTime(2019, 6, 1), new DateTime(2019, 6, 30));
        }
    }
}