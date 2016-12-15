using Wedding.Common.Core;

namespace Wedding.Application.Core
{
    public class SessionFactory : ISessionFactory
    {
        private readonly ISession _session;

        public SessionFactory(ISession session)
        {
            _session = session;
        }

        public ISession Create()
        {
            return _session;
        }
    }
}