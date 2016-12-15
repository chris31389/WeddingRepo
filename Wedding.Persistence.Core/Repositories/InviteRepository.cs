using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Wedding.Domain.Core.Invites;
using Wedding.Persistence.Core.Contexts;

namespace Wedding.Persistence.Core.Repositories
{
    public class InviteRepository : IInviteRepository
    {
        private readonly WeddingDbContext _context;

        public InviteRepository(WeddingDbContext context)
        {
            _context = context;
        }

        public Invite GetByUserId(Guid userId)
        {
            Invite invite = _context
                .Invites
                .Include(x => x.WeddingEvents).ThenInclude(x => x.WeddingEvent)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.MainChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.StarterChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.DessertChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Rsvp)
            .FirstOrDefault(x => x.UserId == userId);
            return invite;
        }

        public Invite GetById(Guid id)
        {
            Invite invite = _context
                .Invites
                .Include(x => x.WeddingEvents).ThenInclude(x => x.WeddingEvent)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.MainChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.StarterChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.DessertChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Rsvp)
                .FirstOrDefault(x => x.Id == id);
            return invite;
        }

        public void Add(Invite invite)
        {
            _context
                .Invites
                .Add(invite);
            _context.SaveChanges();
        }

        public IEnumerable<Invite> GetAll()
        {
            var invites = _context
                .Invites
                .Include(x => x.WeddingEvents).ThenInclude(x => x.WeddingEvent)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.MainChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.StarterChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Meal).ThenInclude(x => x.DessertChoice)
                .Include(x => x.Invitees).ThenInclude(x => x.Rsvp)
                .ToList();

            return invites;
        }
    }
}