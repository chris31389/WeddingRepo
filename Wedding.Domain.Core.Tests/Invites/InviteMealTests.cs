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
    public class InviteMealTests
    {
        private Invite _adultInvite;
        private Invite _childInvite;
        private StarterChoice _adultStarter;
        private MainChoice _adultMain;
        private DessertChoice _adultDessert;
        private StarterChoice _childStarter;
        private MainChoice _childMain;
        private DessertChoice _childDessert;

        [SetUp]
        public void Setup()
        {
            List<WeddingEvent> weddingEvents = new List<WeddingEvent>
            {
                new WeddingEvent("Breakfast")
            };

            List<CreateInviteeDdto> adultInviteeDdtos = new List<CreateInviteeDdto>
            {
                new CreateInviteeDdto
                {
                    Fullname = "Yasmin Giles",
                    IsAdult = true
                }
            };

            _adultInvite = new Invite(Guid.NewGuid(), adultInviteeDdtos, weddingEvents);

            List<CreateInviteeDdto> childInviteeDdtos = new List<CreateInviteeDdto>
            {
                new CreateInviteeDdto
                {
                    Fullname = "Christopher Butler",
                    IsAdult = false
                }
            };

            _childInvite = new Invite(Guid.NewGuid(), childInviteeDdtos, weddingEvents);

            _adultStarter = new StarterChoice("something", "Adult");
            _adultMain = new MainChoice("something", "Adult");
            _adultDessert = new DessertChoice("something", "Adult");
            _childStarter = new StarterChoice("something", "Child");
            _childMain = new MainChoice("something", "Child");
            _childDessert = new DessertChoice("something", "Child");
        }

        [Test]
        public void GivenIsAdult_WhenISaveAdultMeal_Saves()
        {
            Invitee invitee = _adultInvite.Invitees.First();
            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = invitee.Id,
                    StarterChoice = _adultStarter,
                    MainChoice = _adultMain,
                    DessertChoice = _adultDessert
                }
            };
            _adultInvite.AddMeal(mealDdtos);

            Assert.That(invitee.Meal.StarterChoice, Is.EqualTo(_adultStarter));
            Assert.That(invitee.Meal.MainChoice, Is.EqualTo(_adultMain));
            Assert.That(invitee.Meal.DessertChoice, Is.EqualTo(_adultDessert));
        }
        
        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, true)]
        public void GivenIsAdult_WhenITryToSaveChildMeal_ThrowsMealChoiceNotAllowedException(
            bool starterIsAdult,
            bool mainIsAdult,
            bool dessertIsAdult)
        {
            Invitee invitee = _adultInvite.Invitees.First();
            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = invitee.Id,
                    StarterChoice = starterIsAdult ? _adultStarter : _childStarter,
                    MainChoice = mainIsAdult ? _adultMain : _childMain,
                    DessertChoice = dessertIsAdult ? _adultDessert : _childDessert
                }
            };

            Assert.Throws<MealChoiceNotAllowedException>(() => _adultInvite.AddMeal(mealDdtos));
        }
        
        [Test]
        public void GivenIsAdultFalse_WhenITryToSaveChildMeal_Saves()
        {
            Invitee invitee = _childInvite.Invitees.First();
            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = invitee.Id,
                    StarterChoice = _childStarter,
                    MainChoice = _childMain,
                    DessertChoice = _childDessert
                }
            };
            _childInvite.AddMeal(mealDdtos);

            Assert.That(invitee.Meal.StarterChoice, Is.EqualTo(_childStarter));
            Assert.That(invitee.Meal.MainChoice, Is.EqualTo(_childMain));
            Assert.That(invitee.Meal.DessertChoice, Is.EqualTo(_childDessert));
        }

        [TestCase(false, true, false)]
        [TestCase(true, false, false)]
        [TestCase(false, false, true)]
        public void GivenIsAdultFalse_WhenITryToSaveAdultChoice_ThrowsMealChoiceNotAllowedException(
            bool starterIsChild,
            bool mainIsChild,
            bool dessertIsChild)
        {
            Invitee invitee = _childInvite.Invitees.First();
            List<CreateMealDdto> mealDdtos = new List<CreateMealDdto>
            {
                new CreateMealDdto
                {
                    InviteeId = invitee.Id,
                    StarterChoice = starterIsChild ? _childStarter : _adultStarter ,
                    MainChoice = mainIsChild ? _childMain :_adultMain ,
                    DessertChoice = dessertIsChild ? _childDessert :_adultDessert 
                }
            };

            Assert.Throws<MealChoiceNotAllowedException>(() => _childInvite.AddMeal(mealDdtos));
        }

        public void GivenIsAdultFalseAndIsAdultInSameInvite_WhenITryToSaveBothChoices_Saves()
        {

        }
    }
}