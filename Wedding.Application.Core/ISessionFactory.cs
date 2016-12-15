using Wedding.Common.Core;

namespace Wedding.Application.Core
{
    public interface ISessionFactory
    {
        ISession Create();
    }
}