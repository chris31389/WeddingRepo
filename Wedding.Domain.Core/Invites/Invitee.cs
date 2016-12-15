using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public class Invitee : Member<Invite>
    {
        internal Invitee(Invite invite, string fullname, bool isAdult)
            : base(invite)
        {
            Fullname = fullname;
            IsAdult = isAdult;
        }

        protected Invitee()
        {
        }

        public string Fullname { get; private set; }

        public bool IsAdult { get; private set; }

        public Rsvp Rsvp { get; private set; }

        public Meal Meal { get; private set; }

        internal void SetCanCome(bool canCome)
        {
            if (Rsvp == null)
            {
                Rsvp = new Rsvp(this, canCome);
            }
            else
            {
                Rsvp.CanCome = canCome;
            }
        }

        public bool HasReplied => Rsvp != null;

        public void SetMeal(StarterChoice starterChoice, MainChoice mainChoice, DessertChoice dessertChoice, string dietaryRequirements)
        {
            if (Meal == null)
            {
                Meal = new Meal(this, starterChoice, mainChoice, dessertChoice, dietaryRequirements);
            }
            else
            {
                Meal.UpdateMeal(starterChoice, mainChoice, dessertChoice, dietaryRequirements);
            }
        }
    }
}
