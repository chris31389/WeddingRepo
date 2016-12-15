using System;
using System.Collections.Generic;

namespace Wedding.AdminWebApp.Controllers
{
    public class UserWdto
    {
        public string UserName { get; set; }

        public IEnumerable<Guid> WeddingEventIds { get; set; }

        public IEnumerable<InviteeWdto> Invitees { get; set; }
    }
}