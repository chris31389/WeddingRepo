using Moq;
using NUnit.Framework;
using Wedding.Domain.Core.Invites;

namespace Wedding.Domain.Core.Tests.Invites
{
    [TestFixture]
    public class InviteeConstructionTests
    {
        [Test]
        public void GivenValidDetails_WhenIConstruct_ThenIGetAValidInvitee()
        {
            const string fullname = "Yasmin Giles";
            const bool isAdult = true;

            Invitee invitee = new Invitee(Mock.Of<Invite>(), fullname, isAdult);

            Assert.That(invitee, Is.Not.EqualTo(null));
        }

        [Test]
        public void GivenValidName_WhenIConstruct_ThenIGetAValidInvitee()
        {
            const string fullname = "Any Name";
            const bool isAdult = false;

            Invitee invitee = new Invitee(Mock.Of<Invite>(), fullname, isAdult);

            Assert.That(invitee.Fullname, Is.EqualTo(fullname));
        }

        [Test]
        public void GivenValidIsAdult_WhenIConstruct_ThenIGetAValidInvitee()
        {
            const string fullname = "Any Name";
            const bool isAdult = false;

            Invitee invitee = new Invitee(Mock.Of<Invite>(), fullname, isAdult);

            Assert.That(invitee.IsAdult, Is.EqualTo(isAdult));
        }
    }
}