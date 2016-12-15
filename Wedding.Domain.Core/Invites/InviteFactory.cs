using System;
using System.Collections.Generic;
using Wedding.Domain.Core.Invites.Exceptions;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Domain.Core.Invites
{
    public class InviteFactory : IInviteFactory
    {
        private readonly IInviteRepository _inviteRepository;

        public InviteFactory(
            IInviteRepository inviteRepository)
        {
            _inviteRepository = inviteRepository;
        }

        public Invite Create(Guid userId, IEnumerable<CreateInviteeDdto> inviteeDdtos, IEnumerable<WeddingEvent> weddingEvents)
        {
            if (inviteeDdtos == null)
            {
                throw new ArgumentNullException(nameof(inviteeDdtos));
            }

            if (weddingEvents == null)
            {
                throw new ArgumentNullException(nameof(weddingEvents));
            }

            Invite existingInvite = _inviteRepository.GetByUserId(userId);

            if (existingInvite != null)
            {
                string errorMessage = $"Invite for {userId} already exists";
                throw new UserAccountAlreadyAssociatedToInviteException(errorMessage);
            }
        
            Invite invite = new Invite(userId, inviteeDdtos, weddingEvents);
            _inviteRepository.Add(invite);
            return invite;
        }
    }
}