using System;
using System.Collections.Generic;
using NUnit.Framework;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Tests.Invites
{
    [TestFixture]
    public class InviteConstructionTests
    {
        private Guid _userId;

        private ICollection<CreateInviteeDdto> _inviteeDdtos;
        private ICollection<WeddingEvent> _weddingEvents;

        [SetUp]
        public void Setup()
        {
            _userId = Guid.NewGuid();
            _inviteeDdtos = new List<CreateInviteeDdto>
            {
                new CreateInviteeDdto
                {
                    Fullname = "Yasmin Giles",
                    IsAdult = true
                }
            };

            _weddingEvents = new List<WeddingEvent>
            {
                new WeddingEvent("ceremony")
            };
        }

        [Test]
        public void GivenValidInviteesAndAccount_WhenICreate_ThenIGetValidInvite()
        {
            Invite invite = new Invite(_userId, _inviteeDdtos, _weddingEvents);

            Assert.That(invite, Is.Not.EqualTo(null));
        }

        [Test]
        public void GivenValidInviteesAndAccount_WhenICreate_ThenUserAccountIsSet()
        {
            Invite invite = new Invite(_userId, _inviteeDdtos, _weddingEvents);

            Assert.That(invite.UserId, Is.EqualTo(_userId));
        }

        [Test]
        public void GivenValidInviteesAndAccount_WhenICreate_ThenWeddingEventsAreSet()
        {
            Invite invite = new Invite(_userId, _inviteeDdtos, _weddingEvents);

            Assert.That(invite.WeddingEvents.Count, Is.EqualTo(_weddingEvents.Count));
        }

        [Test]
        public void GivenValidInviteesAndAccount_WhenICreate_ThenInvitesAreSet()
        {
            Invite invite = new Invite(_userId, _inviteeDdtos, _weddingEvents);

            Assert.That(invite.Invitees, Is.Not.EqualTo(null));
        }
    }
}