using FluentAssertions;
using IronFoundry.Vcap;
using NUnit.Framework;

namespace IronFoundry.Tests
{
    [TestFixture]
    public class where_vcap_client_is_used
    {
        [TestFixtureSetUp]
        public void when_verifying_cloud_target()
        {
         
        }


        [Test]
        public void Blagh()
        {
            // Just figuring it out, don't look at this test.
            VcapClient client = new VcapClient("http://api.robotech.wa1.wfabric.com");
            client.Login("adron.hall@tier3.com", "77stumptown!");
            var clientInfo = client.GetInfo();
            clientInfo.User.Should().NotBeNull();
        }
    }
}
