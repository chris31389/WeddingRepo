using System;
using Wedding.Common.Core;

namespace Wedding.Persistence.Core.Contexts
{
    public class Session : ISession
    {
        private readonly WeddingDbContext _weddingDbContext;

        public Session(WeddingDbContext weddingDbContext)
        {
            _weddingDbContext = weddingDbContext;
        }

        public int SaveChanges()
        {
            return _weddingDbContext.SaveChanges();
        }

        public void Dispose()
        {
            try
            {
                _weddingDbContext.SaveChanges();
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }
}