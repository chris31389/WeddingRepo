using System;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public class InviteWeddingEvent : Entity
    {
        protected InviteWeddingEvent()
        {
        }

        public virtual Invite Invite { get; private set; }

        public virtual WeddingEvent WeddingEvent { get; private set; }

        public InviteWeddingEvent(Invite invite, WeddingEvent weddingEvent)
        {
            Invite = invite;
            WeddingEvent = weddingEvent;
            Id = new Guid();
        }
    }
}