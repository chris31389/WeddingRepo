using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Application.Core.Exceptions;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Application.Core.Meals
{
    public class MealChoiceService : IMealChoiceService
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IStarterChoiceRepository _starterChoiceRepository;
        private readonly IMainChoiceRepository _mainChoiceRepository;
        private readonly IDessertChoiceRepository _dessertChoiceRepository;
        private readonly IInviteRepository _inviteRepository;

        public MealChoiceService(
            IInviteRepository inviteRepository,
            ISessionFactory sessionFactory,
            IStarterChoiceRepository starterChoiceRepository,
            IMainChoiceRepository mainChoiceRepository,
            IDessertChoiceRepository dessertChoiceRepository )
        {
            _sessionFactory = sessionFactory;
            _starterChoiceRepository = starterChoiceRepository;
            _mainChoiceRepository = mainChoiceRepository;
            _dessertChoiceRepository = dessertChoiceRepository;
            _inviteRepository = inviteRepository;
        }

        public void AddMeal(Guid userId, IEnumerable<CreateMealAdto> createMealAdtos)
        {
            using (_sessionFactory.Create())
            {
                Invite invite = _inviteRepository.GetByUserId(userId);

                if (invite == null)
                {
                    throw new ApplicationException($"invite id {userId} does not exist");
                }

                try
                {
                    ICollection<CreateMealDdto> createMealDdtos = 
                        createMealAdtos.Select(x => new CreateMealDdto
                        {
                            InviteeId = x.InviteeId,
                            StarterChoice = _starterChoiceRepository.GetById(x.StarterChoiceId),
                            MainChoice = _mainChoiceRepository.GetById(x.MainChoiceId),
                            DessertChoice = _dessertChoiceRepository.GetById(x.DessertChoiceId),
                            DietaryRequirements = x.DietaryRequirements
                        }).ToList();

                    invite.AddMeal(createMealDdtos);
                }
                catch (ArgumentException ex)
                {

                    throw new ApplicationException($"could not find your meal choice in the expected meal choices", ex);
                }
            }
        }

        public MealAdto GetMealsByUserId(Guid userId)
        {
            using (_sessionFactory.Create())
            {
                Invite invite = _inviteRepository.GetByUserId(userId);

                if (invite == null)
                {
                    throw new ApplicationException($"invite id {userId} does not exist");
                }

                var mealAdto = new MealAdto
                {
                    SelectedMeals = invite.SelectedMeal,
                    IndividualMealSelections = invite.Invitees.Select(x => new IndividualMealSelectionAdto
                    {
                        InviteeId = x.Id,
                        FullName = x.Fullname,
                        IsAdult = x.IsAdult,
                        MainChoice = x.Meal?.MainChoice?.Id,
                        DessertChoice = x.Meal?.DessertChoice?.Id,
                        StarterChoice = x.Meal?.StarterChoice?.Id,
                        DietaryRequirements = x.Meal?.DietaryRequirements
                    })
                };

                return mealAdto;
            }
        }
    }
}