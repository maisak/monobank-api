using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Monobank.Tests
{
    [TestFixture]
    public class MonoClientTests : TestsBase
    {
        [Test]
        public void InstanceCreated()
        {
            Assert.IsNotNull(Instance);
        }

        [Test]
        public async Task GetCurrencies()
        {
            var currencies = await Instance.Currency.GetCurrencies();
            Assert.IsNotNull(currencies);
            Assert.IsNotEmpty(currencies);
        }

        [Test]
        public async Task GetClientInfo()
        {
            var client = await Instance.Client.GetClientInfoAsync();
            Assert.IsNotNull(client);
            Assert.IsNotEmpty(client.Accounts);
            Assert.IsFalse(string.IsNullOrEmpty(client.Name));
        }

        [Test]
        public async Task GetClientStatement()
        {
            var now = DateTime.UtcNow;
            var statements = await Instance.Client.GetStatementsAsync(now.AddDays(-30), now);
            Assert.IsNotNull(statements);
            Assert.IsNotEmpty(statements);
        }

        [Test]
        public async Task GetClientStatementFailOnTimeRange()
        {
            var now = DateTime.UtcNow;
            Assert.ThrowsAsync(
                Is.TypeOf<Exception>().And.Message.Contains("Time range exceeded"),
                async () =>
                {
                    await Instance.Client.GetStatementsAsync(now.AddDays(-32), now);
                });
        }

        [Test]
        public async Task GetClientStatementFailOnRequestLimit()
        {
            var now = DateTime.UtcNow;
            Assert.ThrowsAsync(
                Is.TypeOf<Exception>().And.Message.Contains("Request limit exceeded"),
                async () =>
                {
                    await Instance.Client.GetStatementsAsync(now.AddDays(-1), now);
                    await Instance.Client.GetStatementsAsync(now.AddDays(-1), now);
                });
        }
    }
}