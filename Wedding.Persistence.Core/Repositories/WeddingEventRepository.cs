using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.ReferenceDatas;
using Wedding.Persistence.Core.Contexts;

namespace Wedding.Persistence.Core.Repositories
{
    public class WeddingEventRepository : IWeddingEventRepository
    {
        private readonly WeddingDbContext _weddingDbContext;

        public WeddingEventRepository(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }

        public WeddingEvent GetById(Guid id)
        {
            WeddingEvent dessertChoice = _weddingDbContext
                .WeddingEvents
                .FirstOrDefault(x => x.Id == id);

            return dessertChoice;
        }

        public IEnumerable<WeddingEvent> GetAll()
        {
            return _weddingDbContext
                .WeddingEvents;
        }
    }
}