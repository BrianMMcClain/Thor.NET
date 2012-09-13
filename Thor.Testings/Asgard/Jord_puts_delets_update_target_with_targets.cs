using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Thor.Asgard;
using Thor.Asgard.Bridges;
using Thor.Models;
using Thor.Models.Jord;

namespace Thor.Testings.Asgard
{
    [TestFixture]
    public class Jord_puts_delets_update_target_with_targets
    {
        protected FoundryTarget target;
        protected Targets targetsBridge;
        protected Guid targetId;
        private ICuzSettingsIsSealedWrapper _wrapper;

        [TestFixtureSetUp]
        public void where_target()
        {
            // this is done in another part of the application, but is done here for testing specifically.
            StaticTestData.MakeSureSettingsJsonFoundryExists();

            _wrapper = Substitute.For<ICuzSettingsIsSealedWrapper>();

            targetsBridge = new Targets(_wrapper);
            target = StaticTestData.SampleFoundryTarget();

            _wrapper.Get().Returns((new Foundry()));
        }

        [Test]
        public void should_put_target_in_with_true_result()
        {
            var foundry = new Foundry();
            foundry.Targets.Add(target);
            targetsBridge.PutTarget(target).Should().BeTrue();

            targetsBridge.DeleteTarget(target);
        }

        [Test]
        public void should_delete_target_after_put_with_true_result()
        {
            var foundry = new Foundry();
            foundry.Targets.Add(target);

            targetsBridge.PutTarget(target);
            targetsBridge.DeleteTarget(target);

            targetsBridge.GetTargets().Count.Should().Be(0);
        }

        [Test]
        public void should_get_targets_results()
        {
            var targets = targetsBridge.GetTargets();
            targetsBridge.PutTarget(target);

            targets.Count.Should().Be(1);

            targetsBridge.DeleteTarget(target);
        }
    }
}