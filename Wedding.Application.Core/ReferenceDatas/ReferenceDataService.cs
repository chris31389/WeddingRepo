using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Application.Core.ReferenceDatas
{
    public class ReferenceDataService : IReferenceDataService
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IWeddingEventRepository _weddingEventRepository;
        private readonly IStarterChoiceRepository _starterChoiceRepository;
        private readonly IMainChoiceRepository _mainChoiceRepository;
        private readonly IDessertChoiceRepository _dessertChoiceRepository;

        public ReferenceDataService(
            ISessionFactory sessionFactory,
            IWeddingEventRepository weddingEventRepository,
            IStarterChoiceRepository starterChoiceRepository,
            IMainChoiceRepository mainChoiceRepository,
            IDessertChoiceRepository dessertChoiceRepository)
        {
            _sessionFactory = sessionFactory;
            _weddingEventRepository = weddingEventRepository;
            _starterChoiceRepository = starterChoiceRepository;
            _mainChoiceRepository = mainChoiceRepository;
            _dessertChoiceRepository = dessertChoiceRepository;
        }

        public IEnumerable<ReferenceDataAdto> GetWeddingEvents()
        {
            using (_sessionFactory.Create())
            {
                IEnumerable<WeddingEvent> weddingEvents = _weddingEventRepository.GetAll();
                IEnumerable<ReferenceDataAdto> referenceDataAdtos = weddingEvents.Select(x => new ReferenceDataAdto(x));
                return referenceDataAdtos;
            }
        }

        public IEnumerable<ExtendedReferenceDataAdto> GetStarterMealChoice()
        {
            using (_sessionFactory.Create())
            {
                IEnumerable<StarterChoice> starterChoices = _starterChoiceRepository.GetAll();
                IEnumerable<ExtendedReferenceDataAdto> referenceDataAdtos = starterChoices.Select(x => new ExtendedReferenceDataAdto(x));
                return referenceDataAdtos;
            }
        }

        public IEnumerable<ExtendedReferenceDataAdto> GetMainMealChoice()
        {
            using (_sessionFactory.Create())
            {
                IEnumerable<MainChoice> starterChoices = _mainChoiceRepository.GetAll();
                IEnumerable<ExtendedReferenceDataAdto> referenceDataAdtos = starterChoices.Select(x => new ExtendedReferenceDataAdto(x));
                return referenceDataAdtos;
            }
        }

        public IEnumerable<ExtendedReferenceDataAdto> GetDessertMealChoice()
        {
            using (_sessionFactory.Create())
            {
                IEnumerable<DessertChoice> starterChoices = _dessertChoiceRepository.GetAll();
                IEnumerable<ExtendedReferenceDataAdto> referenceDataAdtos = starterChoices.Select(x => new ExtendedReferenceDataAdto(x));
                return referenceDataAdtos;
            }
        }
    }
}