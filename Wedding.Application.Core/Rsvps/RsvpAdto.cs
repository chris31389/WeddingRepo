using System;
using System.Collections.Generic;

namespace Wedding.Application.Core.Rsvps
{
    public class RsvpAdto
    {
        public IEnumerable<Guid> WeddingEventIds { get; set; }

        public IEnumerable<IndividualRsvpAdto> IndividualRsvps { get; set; }

        public string Email { get; set; }

        public bool Rsvped { get; set; }
    }
}