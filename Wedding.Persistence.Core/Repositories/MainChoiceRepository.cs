using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.ReferenceDatas;
using Wedding.Persistence.Core.Contexts;

namespace Wedding.Persistence.Core.Repositories
{
    public class MainChoiceRepository : IMainChoiceRepository 
    {
        private readonly WeddingDbContext _weddingDbContext;

        public MainChoiceRepository(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }

        public MainChoice GetById(Guid id)
        {
            MainChoice mainChoice = _weddingDbContext
                .MainChoices
                .FirstOrDefault(x => x.Id == id);

            return mainChoice;
        }

        public IEnumerable<MainChoice> GetAll()
        {
            return _weddingDbContext
                .MainChoices;
        }
    }
}