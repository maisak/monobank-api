using Monobank.Core;
using NUnit.Framework;

namespace Monobank.Tests
{
    public class TestsBase
    {
        protected MonoClient Instance;

        [SetUp]
        public void Setup()
        {
            var config = Configuration.InitConfiguration();
            Instance = new MonoClient(config["ApiKey"]);
        }
    }
}