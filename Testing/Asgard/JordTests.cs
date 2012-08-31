using System;
using FluentAssertions;
using NUnit.Framework;
using Thor.Net.Asgard;

namespace Testing.Asgard
{
    [TestFixture]
    public class JörðTests
    {
        protected Uri apiTarget;

        [TestFixtureSetUp]
        public void where_these_are_self_evident_truths()
        {
            apiTarget = new Uri("http://api.target.com");

        }
    
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
