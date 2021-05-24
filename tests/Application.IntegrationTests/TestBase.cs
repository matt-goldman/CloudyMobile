using NUnit.Framework;
using System.Threading.Tasks;

namespace _2_gt4.Application.IntegrationTests
{
    using static Testing;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
