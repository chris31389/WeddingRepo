using System;

namespace Wedding.Common.Core
{
    public interface ISession: IDisposable
    {
        int SaveChanges();
    }
}