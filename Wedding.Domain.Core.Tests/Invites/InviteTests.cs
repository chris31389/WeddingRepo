using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.Invites.Exceptions;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Tests.Invites
{
    [TestFixture]
    public class InviteTests
    {
        private Invite _invite;
        private const string ValidEmailAddress = "chris@yahoo.co.uk";

        [SetUp]
        public void Setup()
        {
            Guid userId = Guid.NewGuid();
            List<CreateInviteeDdto> inviteeDdtos = new List<CreateInviteeDdto>
            {
                new CreateInviteeDdto
                {
                    Fullname = "Yasmin Giles",
                    IsAdult = true
                }
            };
            List<WeddingEvent> weddingEvents = new List<WeddingEvent>
            {
                new WeddingEvent("Ceremony")
            };

            _invite = new Invite(userId, inviteeDdtos, weddingEvents);
        }

        [TestCase("chris@yahoo.com")]
        [TestCase("chris@yahoo.co.uk")]
        [TestCase("chris31389@yahoo.co.uk")]
        [TestCase("chris31389@G99Gle.co.uk")]
        public void GivenValidEmailAddress_WhenIAddEmailAddress_ThenEmailAddressIsSet(string validEmailAddress)
        {
            _invite.AddRsvp(validEmailAddress, new List<CreateRsvpDdto>());

            Assert.That(_invite.EmailAddress, Is.EqualTo(validEmailAddress));
        }

        [TestCase("chris@")]
        [TestCase("chris")]
        [TestCase("@chris")]
        [TestCase("chris@yahoo")]
        public void GivenInvalidEmailAddress_WhenISetRsvpResponse_ThenThrowsEmailAddressIsInvalidException(string validEmailAddress)
        {
            Assert.Throws<EmailAddressIsInvalidException>(() => _invite.AddRsvp(validEmailAddress, new List<CreateRsvpDdto>()));
        }

        [Test]
        public void GivenInvite_WhenICallSetRsvpResponseWithValidRsvpDdto_ThenTheInviteeRsvpCanComeIsSet()
        {
            Invitee invitee = _invite.Invitees.First();

            List<CreateRsvpDdto> rsvpDdtos = new List<CreateRsvpDdto>
            {
                new CreateRsvpDdto
                {
                    InviteeId = invitee.Id,
                    CanCome = true
                }
            };

            _invite.AddRsvp(ValidEmailAddress, rsvpDdtos);
            Assert.That(invitee.Rsvp.CanCome, Is.EqualTo(true));
        }

        [Test]
        public void GivenInviteThatDoesntExist_WhenICallSetRsvpResponseWithValidRsvpDdto_ThenThrowsInviteeCouldNotBeFoundException()
        {
            List<CreateRsvpDdto> rsvpDdtos = new List<CreateRsvpDdto>
            {
                new CreateRsvpDdto
                {
                    InviteeId = Guid.NewGuid(),
                    CanCome = true
                }
            };

            Assert.Throws<InviteeCouldNotBeFoundException>(() => _invite.AddRsvp(ValidEmailAddress, rsvpDdtos));
        }

        [Test]
        public void GivenInvite_WhenICallSetMealWithValidMealDdto_ThenTheInviteeMealChoicesAreSet()
        {
            Invitee invitee = _invite.Invitees.First();
            MainChoice mainChoice = new MainChoice("Lamb", "Adult");
            DessertChoice dessertChoice = new DessertChoice("Brulee", "Adult");
            StarterChoice starterChoice = new StarterChoice("Duck", "Adult");

            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = invitee.Id,
                    MainChoice = mainChoice,
                    DessertChoice = dessertChoice,
                    StarterChoice = starterChoice
                }
            };

            _invite.AddMeal(mealDdtos);

            Assert.That(invitee.Meal.MainChoice, Is.EqualTo(mainChoice));
            Assert.That(invitee.Meal.DessertChoice, Is.EqualTo(dessertChoice));
            Assert.That(invitee.Meal.StarterChoice, Is.EqualTo(starterChoice));
        }

        [Test]
        public void GivenInviteThatDoesntExist_WhenICallSetMealWithValidMealDdto_ThenThrowsInviteeCouldNotBeFoundException()
        {
            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = Guid.NewGuid(),
                    MainChoice = new MainChoice("Lamb", "Adult"),
                    DessertChoice =  new DessertChoice("Brulee", "Adult"),
                    StarterChoice =  new StarterChoice("Duck", "Adult")
                }
            };

            Assert.Throws<InviteeCouldNotBeFoundException>(() => _invite.AddMeal(mealDdtos));
        }

        [Test]
        public void GivenNoRsvps_WhenIGetRsvped_ThenIGetFalse()
        {
            Assert.That(_invite.Rsvped, Is.EqualTo(false));
        }

        [Test]
        public void GivenAnRsvp_WhenIGetRsvped_ThenIGetTrue()
        {
            _invite.AddRsvp("email@yahoo.com", new List<CreateRsvpDdto>
            {
                new CreateRsvpDdto
                {
                    CanCome = true,
                    InviteeId = _invite.Invitees.First().Id
                }
            });

            Assert.That(_invite.Rsvped, Is.EqualTo(true));
        }

        [Test]
        public void GivenNoMeals_WhenIGetSelectedMeal_ThenIGetFalse()
        {
            Assert.That(_invite.SelectedMeal, Is.EqualTo(false));
        }

        [Test]
        public void GivenAnMeal_WhenIGetSelectedMeal_ThenIGetTrue()
        {
            Invitee invitee = _invite.Invitees.First();
            MainChoice mainChoice = new MainChoice("Lamb", "Adult");
            DessertChoice dessertChoice = new DessertChoice("Brulee", "Adult");
            StarterChoice starterChoice = new StarterChoice("Duck", "Adult");

            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = invitee.Id,
                    MainChoice = mainChoice,
                    DessertChoice = dessertChoice,
                    StarterChoice = starterChoice
                }
            };

            _invite.AddMeal(mealDdtos);

            Assert.That(_invite.SelectedMeal, Is.EqualTo(true));
        }
    }
}