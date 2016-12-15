using System;
using System.Collections.Generic;
using System.Linq;
using Wedding.Domain.Core.Invites;
using Wedding.Domain.Core.Invites.Exceptions;
using Wedding.Domain.Core.ReferenceDatas;

namespace Wedding.Application.Core.Invites
{
    public class InviteService : IInviteService
    {
        private readonly IInviteFactory _inviteFactory;
        private readonly ISessionFactory _sessionFactory;
        private readonly IWeddingEventRepository _weddingEventRepository;
        private readonly IInviteRepository _inviteRepository;

        public InviteService(
            IInviteFactory inviteFactory,
            ISessionFactory sessionFactory,
            IWeddingEventRepository weddingEventRepository,
            IInviteRepository inviteRepository
            )
        {
            _inviteFactory = inviteFactory;
            _sessionFactory = sessionFactory;
            _weddingEventRepository = weddingEventRepository;
            _inviteRepository = inviteRepository;
        }

        public InviteAdto Create(CreateInviteAdto createInviteAdto)
        {
            using (_sessionFactory.Create())
            {
                if (createInviteAdto == null)
                {
                    throw new ArgumentNullException(nameof(createInviteAdto));
                }
                
                IEnumerable<CreateInviteeDdto> createInviteeDdtos = createInviteAdto
                    .CreateInviteeAdtos
                    .Select(x => new CreateInviteeDdto
                    {
                        Fullname = x.Fullname,
                        IsAdult = x.IsAdult
                    }).ToList();

                List<WeddingEvent> weddingEvents = new List<WeddingEvent>();

                foreach (Guid weddingEventId in createInviteAdto.WeddingEventIds)
                {
                    WeddingEvent weddingEvent = _weddingEventRepository.GetById(weddingEventId);
                    if (weddingEvent == null)
                    {
                        throw new ArgumentOutOfRangeException(nameof(weddingEventId));
                    }

                    weddingEvents.Add(weddingEvent);
                }

                Invite invite = CreateInvite(weddingEvents, createInviteAdto.UserId, createInviteeDdtos);
                InviteAdto inviteAdto = new InviteAdto(invite);

                return inviteAdto;
            }
        }

        private Invite CreateInvite(
            IEnumerable<WeddingEvent> weddingEvents,
            Guid userId,
            IEnumerable<CreateInviteeDdto> createInviteeDdtos)
        {
            try
            {
                Invite invite = _inviteFactory.Create(userId, createInviteeDdtos, weddingEvents);
                return invite;
            }
            catch (UserAccountAlreadyAssociatedToInviteException userAccountAlreadyAssociatedToInviteException)
            {
                // TODO: Convert to generic error exception
                Console.WriteLine(userAccountAlreadyAssociatedToInviteException);
                throw;
            }
        }
        
        public IEnumerable<InviteAdto> Create(IEnumerable<CreateInviteAdto> createInviteAdto)
        {
            using (_sessionFactory.Create())
            {
                IEnumerable<InviteAdto> inviteAdtos = createInviteAdto.Select(Create);
                return inviteAdtos;
            }
        }

        public IEnumerable<InviteAdto> GetAll()
        {
            using (_sessionFactory.Create())
            {
                var invites = _inviteRepository.GetAll();
                var inviteAdtos = invites.Select(x => new InviteAdto(x));
                return inviteAdtos;
            }
        }

        public InviteAdto GetSingle(Guid id)
        {
            using (_sessionFactory.Create())
            {
                var invite = _inviteRepository.GetById(id);
                var inviteAdto = new InviteAdto(invite);
                return inviteAdto;
            }
        }

        public InviteAdto GetSingleByUserId(Guid userId)
        {
            using (_sessionFactory.Create())
            {
                var invite = _inviteRepository.GetByUserId(userId);
                var inviteAdto = new InviteAdto(invite);
                return inviteAdto;
            }
        }
    }
}