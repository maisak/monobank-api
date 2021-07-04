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
            Assert.IsNotNull(currencies);
            Assert.IsNotEmpty(currencies);
        }

        [Test]
        public async Task GetClientInfo()
        {
            var client = await _client.Client.GetClientInfo();
            Assert.IsNotNull(client);
            Assert.IsNotEmpty(client.Accounts);
            Assert.IsFalse(string.IsNullOrEmpty(client.Name));
        }

        [Test]
        public async Task GetClientStatement()
        {
            var statements = await _client.Client.GetStatements(new DateTime(2021, 6, 1), new DateTime(2021, 6, 30));
            Assert.IsNotNull(statements);
            Assert.IsNotEmpty(statements);
        }

        [Test]
        public async Task GetClientStatementFailOffset()
        {
            Exception exception = null;
            try
            {
                await _client.Client.GetStatements(new DateTime(2021, 6, 1), new DateTime(2021, 7, 30));
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual("Time range exceeds allowed. Difference between from and to should less then 31 day + 1 hour", exception?.Message);
        }

        [Test]
        public async Task GetClientStatementFailTooManyRequests()
        {
            Exception exception = null;
            try
            {
                await _client.Client.GetStatements(new DateTime(2021, 5, 1), new DateTime(2021, 5, 30));
                await _client.Client.GetStatements(new DateTime(2021, 6, 1), new DateTime(2021, 6, 30));
            }
            catch (Exception e)
            {
                exception = e;
            }

            Assert.AreEqual("Too many requests. Only 1 request per 60 seconds", exception?.Message);
        }
    }
}