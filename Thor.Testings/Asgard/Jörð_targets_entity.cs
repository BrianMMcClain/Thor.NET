using System;
using FluentAssertions;
using NUnit.Framework;
using Thor.Models.Jord;

namespace Thor.Testings.Asgard
{
    [TestFixture]
    public class Jörð_targets_entity
    {
        protected FoundryTarget target;
        protected Guid targetId;

        [TestFixtureSetUp]
        public void where_target()
        {
            target = StaticTestData.SampleFoundryTarget();
        }

        [Test]
        public void target_should_never_have_null_or_zeroed_id()
        {
            var newTarget = new FoundryTarget();
            newTarget.Id.Should().NotBe(Guid.Empty);
        }
    }
}