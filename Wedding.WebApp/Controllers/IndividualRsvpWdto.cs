using System;

namespace Wedding.WebApp.Controllers
{
    public class IndividualRsvpWdto
    {
        public Guid InviteeId { get; set; }

        public bool CanCome { get; set; }
    }
}