using Moq;
using NUnit.Framework;
using Wedding.Domain.Core.Invites;

namespace Wedding.Domain.Core.Tests.Invites
{
    [TestFixture]
    public class InviteeTests
    {
        private Invitee _invitee;

        [SetUp]
        public void Setup()
        {
            const string fullname = "Yasmin Giles";
            const bool isAdult = true;

            _invitee = new Invitee(Mock.Of<Invite>(), fullname, isAdult);
        }

        [Test]
        public void WhenICallCanCome_ThenRsvpCanComeIsSetToTrue()
        {
            _invitee.SetCanCome(true);
            bool canCome = _invitee.Rsvp.CanCome;
            Assert.That(canCome, Is.EqualTo(true));
        }

        [Test]
        public void WhenICallCantCome_ThenRsvpCanComeIsSetToFalse()
        {
            _invitee.SetCanCome(false);
            bool canCome = _invitee.Rsvp.CanCome;
            Assert.That(canCome, Is.EqualTo(false));
        }

        [Test]
        public void WhenICallCanComeThenCantCome_ThenExistingRsvpGetsUpdated()
        {
            _invitee.SetCanCome(true);
            Rsvp rsvp1 = _invitee.Rsvp;
            _invitee.SetCanCome(false);
            Rsvp rsvp2 = _invitee.Rsvp;
            Assert.That(rsvp1, Is.EqualTo(rsvp2));
        }
        
        [Test]
        public void WhenICallCanComeThenCantCome_ThenExistingRsvpGetsUpdatedToFalse()
        {
            _invitee.SetCanCome(true);
            _invitee.SetCanCome(false);
            Assert.That(_invitee.Rsvp.CanCome, Is.EqualTo(false));
        }
    }
}