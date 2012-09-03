using System;
using FluentAssertions;
using NUnit.Framework;
using Thor.Net.Asgard.Bridges;
using Thor.Net.Models.Jörð;

namespace Testing.Asgard
{
    [TestFixture]
    public class Jörð_puts_delets_update_target_with_targets
    {
        protected FoundryTarget target;
        protected Targets targetsBridge;
        protected Guid targetId;

        [TestFixtureSetUp]
        public void where_target()
        {
            // this is done in another part of the application, but is done here for testing specifically.
           StaticTestData.MakeSureSettingsJsonFoundryExists();

            targetsBridge = new Targets();
            target = StaticTestData.SampleFoundryTarget();
        }

        [TestFixtureTearDown]
        public void when_done()
        {
            targetsBridge.DeleteTarget(target);
        }

        [Test]
        public void should_put_target_in_with_true_result()
        {
            targetsBridge.PutTarget(target).Should().Be(true);
        }

    }
}