using System;

namespace Wedding.Application.Core.Rsvps
{
    public class IndividualRsvpAdto
    {
        public Guid InviteeId { get; set; }

        public bool CanCome { get; set; }

        public string FullName { get; set; }
    }
}