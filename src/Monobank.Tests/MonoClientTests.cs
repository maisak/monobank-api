using FluentAssertions;
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
            Instance.Should().NotBeNull();
        }

        [Test]
        public async Task GetCurrencies()
        {
            var currencies = await Instance.Currency.GetCurrencies();
            currencies.Should().NotBeNull();
            currencies.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetClientInfo()
        {
            var client = await Instance.Client.GetClientInfoAsync();
            client.Should().NotBeNull();
            client.Accounts.Should().NotBeEmpty();
            client.Name.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetClientStatement()
        {
            var now = DateTime.UtcNow;
            var statements = await Instance.Client.GetStatementsAsync(now.AddDays(-30), now);
            statements.Should().NotBeNull();
            statements.Should().NotBeEmpty();
        }

        [Test]
        public async Task GetClientStatementFailOnTimeRange()
        {
            var now = DateTime.UtcNow;
            
            await FluentActions
                .Invoking(async () =>
                    {
                        await Instance.Client.GetStatementsAsync(now.AddDays(-32), now);
                    })
                .Should()
                .ThrowAsync<Exception>()
                .WithMessage("*Time range exceeded*");
        }

        [Test]
        public async Task GetClientStatementFailOnRequestLimit()
        {
            var now = DateTime.UtcNow;
            await FluentActions.Invoking(async () =>
                {
                    await Instance.Client.GetStatementsAsync(now.AddDays(-1), now);
                    await Instance.Client.GetStatementsAsync(now.AddDays(-1), now);
                })
                .Should()
                .ThrowAsync<Exception>()
                .WithMessage("*Request limit exceeded*");
        }
    }
}