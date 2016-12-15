using System;
using System.Collections.Generic;

namespace Wedding.Application.Core.Meals
{
    public interface IMealChoiceService
    {
        void AddMeal(Guid userId, IEnumerable<CreateMealAdto> createMealAdtos);

        MealAdto GetMealsByUserId(Guid userId);
    }
}