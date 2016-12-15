using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.Invites;

namespace Wedding.Application.Core.Invites
{
    public class InviteAdto
    {
        public InviteAdto(Invite invite)
        {
            WeddingEvents = invite.WeddingEvents.Select(x => x.WeddingEvent.Id);
            Invitees = invite.Invitees.Select(x => new InviteeAdto(x)).ToList();
            Id = invite.Id;
        }

        public Guid Id { get; private set; }
        
        public IEnumerable<Guid> WeddingEvents { get; private set; }

        public IEnumerable<InviteeAdto> Invitees { get; private set; }
    }
}