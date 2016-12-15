using System.Collections.Generic;

namespace Wedding.Application.Core.Meals
{
    public class MealAdto
    {
        public IEnumerable<IndividualMealSelectionAdto> IndividualMealSelections { get; set; }

        public bool SelectedMeals { get; set; }
    }
}