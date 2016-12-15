namespace Wedding.Domain.Core.Invites
{
    public class MealValidator : IMealValidator
    {
        private const string Adult = "Adult";
        private const string Child = "Child";

        public MealValidator()
        {
        }

        public bool Validate(bool isAdult, CreateMealDdto createMealDdto)
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