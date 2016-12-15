using System;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.Invites.Exceptions;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Tests.Invites
{
    [TestFixture]
    public class InviteFactoryTests
    {
        private InviteFactory _inviteFactory;

        private Mock<IInviteRepository> _inviteRepositoryMock;

        private List<CreateInviteeDdto> _inviteeDdtos;

        private Guid _userId;

        private List<WeddingEvent> _weddingEvents;

        [SetUp]
        public void Setup()
        {
            _inviteRepositoryMock = new Mock<IInviteRepository>();
            _inviteFactory = new InviteFactory(
                _inviteRepositoryMock.Object);

            _userId = Guid.NewGuid();
            _inviteeDdtos = new List<CreateInviteeDdto>
            {
                new CreateInviteeDdto
                {
                    Fullname = "Hi",
                    IsAdult = true
                }
            };
            _weddingEvents = new List<WeddingEvent>
            {
                new WeddingEvent("Breakfast")
            };
        }

        [Test]
        public void GivenAUserAccountAndAnInviteDdtoAndAWeddingEvent_WhenICallCreate_IGetANewInvite()
        {
            Invite invite = _inviteFactory.Create(_userId, _inviteeDdtos, _weddingEvents);

            Assert.That(invite, Is.Not.EqualTo(null));
        }

        [Test]
        public void GivenAUserAccountAndAnInviteDdtoAndAWeddingEventWhereTheUserAccountAlreadyHasAnInvite_WhenICallCreate_ThrowsUserAccountAlreadyAssociatedToInviteException()
        {
            _inviteRepositoryMock.Setup(x => x.GetByUserId(_userId)).Returns(Mock.Of<Invite>());

            Assert.Throws<UserAccountAlreadyAssociatedToInviteException>(() => _inviteFactory.Create(_userId, _inviteeDdtos, _weddingEvents));
        }
        
        [Test]
        public void GivenAUserAccountAndAnInviteDdtoAndAWeddingEvent_WhenICallCreate_IAddIsCalledOnTheRepository()
        {
            Invite invite = _inviteFactory.Create(_userId, _inviteeDdtos, _weddingEvents);

            _inviteRepositoryMock.Verify(x => x.Add(invite));

            Assert.That(invite, Is.Not.EqualTo(null));
        }
    }
}
