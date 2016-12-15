using System;
using System.Collections.Generic;

namespace Wedding.Domain.Core.Invites
{
    public interface IInviteRepository
    {
        Invite GetByUserId(Guid userId);

        Invite GetById(Guid id);

        void Add(Invite invite);

        IEnumerable<Invite> GetAll();
    }
}