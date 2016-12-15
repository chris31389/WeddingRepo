using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Wedding.Domain.Core.Invites.Exceptions;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public class Invite : Entity
    {
        private const string Adult = "Adult";
        private const string Child = "Child";
        private const string EmailRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";

        internal Invite(
            Guid userId,
            IEnumerable<CreateInviteeDdto> inviteeDdtos,
            IEnumerable<WeddingEvent> weddingEvents)
        {
            if (inviteeDdtos == null)
            {
                throw new ArgumentNullException(nameof(inviteeDdtos));
            }

            if (weddingEvents == null)
            {
                throw new ArgumentNullException(nameof(weddingEvents));
            }

            UserId = userId;
            WeddingEvents = weddingEvents.Select(x => new InviteWeddingEvent(this, x)).ToList();
            Invitees = inviteeDdtos
                .Select(inviteeDdto => new Invitee(this,inviteeDdto.Fullname, inviteeDdto.IsAdult))
                .ToList();
            Id = Guid.NewGuid();
        }

        protected Invite()
        {
        }
        
        public string EmailAddress { get; private set; }

        public Guid UserId { get; private set; }

        public bool Rsvped
        {
            get
            {
                return Invitees.Count > 0 && Invitees.All(x => x.Rsvp != null);
            }
        }

        public bool SelectedMeal
        {
            get
            {
                return Invitees.Count > 0
                       && Invitees.All(x => x.Meal != null)
                       && Invitees.All(x => x.Meal.StarterChoice != null)
                       && Invitees.All(x => x.Meal.MainChoice != null)
                       && Invitees.All(x => x.Meal.DessertChoice != null);
            }
        }

        public virtual ICollection<InviteWeddingEvent> WeddingEvents { get; private set; }

        public virtual ICollection<Invitee> Invitees { get; private set; }
        
        public void AddRsvp(string email, IEnumerable<CreateRsvpDdto> rsvpDdtos)
        {
            if (!Regex.IsMatch(email, EmailRegex, RegexOptions.IgnoreCase))
            {
                throw new EmailAddressIsInvalidException();
            }

            foreach (CreateRsvpDdto rsvpDdto in rsvpDdtos)
            {
                Invitee invitee = Invitees.FirstOrDefault(x => x.Id == rsvpDdto.InviteeId);

                if (invitee == null)
                {
                    throw new InviteeCouldNotBeFoundException(rsvpDdto.InviteeId.ToString());
                }

                invitee.SetCanCome(rsvpDdto.CanCome);
            }

            EmailAddress = email;
        }

        public void AddMeal(IEnumerable<CreateMealDdto> mealDdtos)
        {
            foreach (CreateMealDdto createMealDdto in mealDdtos)
            {
                Invitee invitee = Invitees.FirstOrDefault(x => x.Id == createMealDdto.InviteeId);

                if (invitee == null)
                {
                    throw new InviteeCouldNotBeFoundException(createMealDdto.InviteeId.ToString());
                }

                if (!IsValidMeal(invitee.IsAdult, createMealDdto))
                {
                    throw new MealChoiceNotAllowedException($"starter: {createMealDdto.StarterChoice.Value}, main: {createMealDdto.MainChoice.Value}, dessert: {createMealDdto.DessertChoice.Value}");
                }
                
                invitee.SetMeal(
                    createMealDdto.StarterChoice, 
                    createMealDdto.MainChoice, 
                    createMealDdto.DessertChoice,
                    createMealDdto.DietaryRequirements
                    );
            }
        }

        private bool IsValidMeal(bool isAdult, CreateMealDdto createMealDdto)
        {
            return isAdult
                ? string.Equals(createMealDdto.StarterChoice.SecondaryValue, Adult)
                  && string.Equals(createMealDdto.MainChoice.SecondaryValue, Adult)
                  && string.Equals(createMealDdto.DessertChoice.SecondaryValue, Adult)
                : string.Equals(createMealDdto.StarterChoice.SecondaryValue, Child)
                  && string.Equals(createMealDdto.MainChoice.SecondaryValue, Child)
                  && string.Equals(createMealDdto.DessertChoice.SecondaryValue, Child);
        }
    }
}