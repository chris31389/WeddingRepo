using System;
using NUnit.Framework;

namespace Wedding.Domain.Core.Tests
{
    [TestFixture]
    public class AggregateMemberTests
    {
        [Test]
        public void GivenInvite_WhenIConstruct_ThenICanSeeInviteIsNowTheParentProperty()
        {
            Object o = new Object();

            AggregateMember aggregateMember = new AggregateMember(o);

            Assert.That(aggregateMember.Parent, Is.EqualTo(o));
        }
    }
}