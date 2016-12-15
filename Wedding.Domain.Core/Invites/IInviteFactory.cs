using System;
using System.Collections.Generic;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public interface IInviteFactory
    {
        Invite Create(Guid userId, IEnumerable<CreateInviteeDdto> inviteeDdtos, IEnumerable<WeddingEvent> weddingEvents);
    }
}