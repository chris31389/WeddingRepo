using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Application.Core.Exceptions;
using Wedding.Domain.Core.Invites;

namespace Wedding.Application.Core.Rsvps
{
    public class RsvpService : IRsvpService
    {
        private readonly ISessionFactory _sessionFactory;
        private readonly IInviteRepository _inviteRepository;

        public RsvpService(
            IInviteRepository inviteRepository,
            ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
            _inviteRepository = inviteRepository;
        }

        public void AddRsvp(Guid userId, string email, IEnumerable<CreateRsvpAdto> createRsvpAdtos)
        {
            using (_sessionFactory.Create())
            {
                Invite invite = _inviteRepository.GetByUserId(userId);

                if (invite == null)
                {
                    throw new ApplicationException($"invite id {userId} does not exist");
                }

                ICollection<CreateRsvpDdto> createRsvpDdtos = createRsvpAdtos
                    .Select(x => new CreateRsvpDdto
                    {
                        InviteeId = x.InviteeId,
                        CanCome = x.CanCome
                    }).ToList();

                invite.AddRsvp(email, createRsvpDdtos);
            }
        }

        public RsvpAdto GetByUserId(Guid userId)
        {
            using (_sessionFactory.Create())
            {
                Invite invite = _inviteRepository.GetByUserId(userId);
                RsvpAdto rsvpAdto = new RsvpAdto
                {
                    Email = invite.EmailAddress,
                    Rsvped = invite.Rsvped,
                    WeddingEventIds = invite.WeddingEvents.Select(x => x.WeddingEvent.Id),
                    IndividualRsvps = invite.Invitees.Select(x => new IndividualRsvpAdto
                    {
                        InviteeId = x.Id,
                        FullName = x.Fullname,
                        CanCome = x.Rsvp?.CanCome ?? false
                    })
                };

                return rsvpAdto;
            }
        }
    }
}