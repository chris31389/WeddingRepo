using System;

namespace Wedding.Common.Core
{
    public interface IAggregateRoot
    {
        Guid Id { get; }
    }
}