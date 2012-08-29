using FluentAssertions;
using Foundry.Asgard;
using NUnit.Framework;

namespace Testing.Asgard
{
    [TestFixture]
    public class JörðTests
    {
        [Test]
        public void should_class_exist()
        {
            (new Jörð()).Should().NotBeNull();
        }

        [Test]
        public void should_be_set_to_run_local()
        {
            (new Jörð()).LocalAccessOnly.Should().BeTrue();
        }
    }
}
