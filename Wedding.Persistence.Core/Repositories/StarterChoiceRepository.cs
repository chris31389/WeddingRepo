using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.ReferenceDatas;
using Wedding.Persistence.Core.Contexts;

namespace Wedding.Persistence.Core.Repositories
{
    public class StarterChoiceRepository : IStarterChoiceRepository 
    {
        private readonly WeddingDbContext _weddingDbContext;

        public StarterChoiceRepository(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }

        public StarterChoice GetById(Guid id)
        {
            StarterChoice starterChoice = _weddingDbContext
                .StarterChoices
                .FirstOrDefault(x => x.Id == id);

            return starterChoice;
        }

        public IEnumerable<StarterChoice> GetAll()
        {
            return _weddingDbContext
                .StarterChoices;
        }
    }
}