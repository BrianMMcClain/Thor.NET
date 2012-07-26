using System;
using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using Thor.Net.Hamma;

namespace Thor.Net.Tests
{
    [TestFixture]
    public class TestingTesting
    {
        [Test]
        public void TestingTestingFramework()
        {
            true.Should().BeTrue();
        }
    }

    [TestFixture]
    public class CloudFoundryTests
    {
        protected ICloudFoundryCommunicator mockedCommunicator;
        protected Uri goodCloudUri;
        protected Uri badCloudUri;

        [TestFixtureSetUp]
        public void SetupTheCloudFoundryMock()
        {
            goodCloudUri = new Uri("http://api.robotech.wa1.wfabric.com");
            badCloudUri = new Uri("http://api.wrongplace.com");
            mockedCommunicator = Substitute.For<ICloudFoundryCommunicator>();
            mockedCommunicator.SetTarget(goodCloudUri).Returns(true);
            mockedCommunicator.SetTarget(badCloudUri).Returns(false);
        }

        [Test]
        public void cloud_foundry_should_target_a_cloud()
        {
            var cloudFoundry = new CloudFoundry(mockedCommunicator);
            Assert.IsTrue(cloudFoundry.SetTarget(goodCloudUri));
        }

        [Test]
        public void cloud_foundry_should_not_target_invalid_cloud()
        {
            var cloudFoundry = new CloudFoundry(mockedCommunicator);
            Assert.IsFalse(cloudFoundry.SetTarget(badCloudUri));
        }


    }
}
