using System;
using Wedding.Common.Core;

namespace Wedding.Domain.Core
{
    public class Entity : IAggregateRoot
    {
        public Guid Id { get; protected set; }
    }
}
