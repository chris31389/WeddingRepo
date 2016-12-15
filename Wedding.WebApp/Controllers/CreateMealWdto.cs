using System.Collections.Generic;

namespace Wedding.WebApp.Controllers
{
    public class CreateMealWdto
    {
        public IEnumerable<CreateIndividualMealSelectionWdto> IndividualMealSelections { get; set; }
    }
}