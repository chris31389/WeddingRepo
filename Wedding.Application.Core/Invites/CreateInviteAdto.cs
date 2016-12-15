using System;
using System.Collections.Generic;

namespace Wedding.Application.Core.Invites
{
    public class CreateInviteAdto
    {
        public Guid UserId { get; set; }

        public IEnumerable<Guid> WeddingEventIds { get; set; }

        public IEnumerable<CreateInviteeAdto> CreateInviteeAdtos { get; set; }
    }
}