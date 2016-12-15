using System;

namespace Wedding.Domain.Core.Invites
{
    public class CreateRsvpDdto
    {
        public Guid InviteeId { get; set; }

        public bool CanCome { get; set; }
    }
}