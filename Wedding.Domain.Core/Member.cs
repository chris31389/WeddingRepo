using System;
using Wedding.Common.Core;

namespace Wedding.Domain.Core
{
    public class Member<T> : IAggregateMember<T> where T : class
    {
        public Member(T parent)
        {
            Parent = parent;
            Id = Guid.NewGuid();
        }

        protected Member()
        {
        }

        public T Parent { get; }

        public Guid Id { get; protected set; }
    }
}