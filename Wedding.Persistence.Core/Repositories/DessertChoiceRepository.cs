using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.ReferenceDatas;
using Wedding.Persistence.Core.Contexts;

namespace Wedding.Persistence.Core.Repositories
{
    public class DessertChoiceRepository : IDessertChoiceRepository
    {
        private readonly WeddingDbContext _weddingDbContext;

        public DessertChoiceRepository(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }

        public DessertChoice GetById(Guid id)
        {
            DessertChoice dessertChoice = _weddingDbContext
                .DessertChoices
                .FirstOrDefault(x => x.Id == id);

            return dessertChoice;
        }

        public IEnumerable<DessertChoice> GetAll()
        {
            return _weddingDbContext
                .DessertChoices;
        }
    }
}