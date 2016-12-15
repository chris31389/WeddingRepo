using System.Collections.Generic;

namespace Wedding.Application.Core.ReferenceDatas
{
    public interface IReferenceDataService
    {
        IEnumerable<ReferenceDataAdto> GetWeddingEvents();

        IEnumerable<ExtendedReferenceDataAdto> GetStarterMealChoice();

        IEnumerable<ExtendedReferenceDataAdto> GetMainMealChoice();

        IEnumerable<ExtendedReferenceDataAdto> GetDessertMealChoice();
    }
}