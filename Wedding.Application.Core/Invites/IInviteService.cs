using System;
using System.Collections.Generic;

namespace Wedding.Application.Core.Invites
{
    public interface IInviteService
    {
        InviteAdto Create(CreateInviteAdto createInviteAdto);

        IEnumerable<InviteAdto> Create(IEnumerable<CreateInviteAdto> createInviteAdto);

        IEnumerable<InviteAdto> GetAll();

        InviteAdto GetSingle(Guid id);

        InviteAdto GetSingleByUserId(Guid userId);
    }
}