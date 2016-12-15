using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public class Meal : Member<Invitee>
    {
        protected Meal()
        {
        }

        public Meal(Invitee invitee, StarterChoice starterChoice, MainChoice mainChoice, DessertChoice dessertChoice, string dietaryRequirements) 
            : base(invitee)
        {
            StarterChoice = starterChoice;
            MainChoice = mainChoice;
            DessertChoice = dessertChoice;
            DietaryRequirements = dietaryRequirements;
        }

        public StarterChoice StarterChoice { get; private set; }

        public MainChoice MainChoice { get; private set; }

        public DessertChoice DessertChoice { get; private set; }
        
        public string DietaryRequirements { get; set; }
        
        internal void UpdateMeal(StarterChoice starterChoice, MainChoice mainChoice, DessertChoice dessertChoice, string dietaryRequirements)
        {
            StarterChoice = starterChoice;
            MainChoice = mainChoice;
            DessertChoice = dessertChoice;
            DietaryRequirements = dietaryRequirements;
        }
    }
}