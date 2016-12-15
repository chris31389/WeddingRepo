using System;

namespace Wedding.Application.Core.Rsvps
{
    public class CreateRsvpAdto
    {
        public Guid InviteeId { get; set; }

        public bool CanCome { get; set; }
    }
}