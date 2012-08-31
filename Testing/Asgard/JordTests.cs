using System;
using FluentAssertions;
using NUnit.Framework;
using Thor.Net.Asgard;
using Thor.Net.Asgard.Bridges;
using Thor.Net.Models;

namespace Testing.Asgard
{
    [TestFixture]
    public class JörðTests
    {
        protected Uri apiTarget;
        protected IRainbowBridge bridge;
        protected FoundryTarget target;
        protected Guid targetId;

        [TestFixtureSetUp]
        public void where_target()
        {
            bridge = new Targets();
            targetId = Guid.NewGuid();
            target = new FoundryTarget()
                         {
                             Created = DateTime.Now.AddDays(-4),
                             Id = targetId,
                             Name = "Testing Target",
                             Notes = "Some testing notes go here.",
                             Path = new Uri("http://api.thetestplace.com"),
                             Stamp = DateTime.Now.AddHours(-4)
                         };
        }

     


    }
}
