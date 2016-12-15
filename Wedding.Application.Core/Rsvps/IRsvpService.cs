using System;
using System.Collections.Generic;

namespace Wedding.Application.Core.Rsvps
{
    public interface IRsvpService
    {
        void AddRsvp(Guid userId, string email, IEnumerable<CreateRsvpAdto> createRsvpAdtos);

        RsvpAdto GetByUserId(Guid userId);
    }
}