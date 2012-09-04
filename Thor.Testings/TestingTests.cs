using FluentAssertions;
using NUnit.Framework;

namespace Thor.Testings
{
    [TestFixture]
    class TestingTests
    {
        [Test]
        public void TestWorks()
        {
            true.Should().BeTrue();
        }
    }
}
