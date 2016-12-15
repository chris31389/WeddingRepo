using System;
using Wedding.Domain.Core.Invites;

namespace Wedding.Application.Core.Invites
{
    public class InviteeAdto
    {
        public InviteeAdto(Invitee invitee)
        {
            Fullname = invitee.Fullname;
            Id = invitee.Id;
            CanCome = invitee.Rsvp?.CanCome ?? false;
            IsAdult = invitee.IsAdult;
            StarterChoice = invitee.Meal?.StarterChoice.Id;
            MainChoice = invitee.Meal?.MainChoice.Id;
            DessertChoice = invitee.Meal?.DessertChoice.Id;
            HasReplied = invitee.HasReplied;
        }

        public string Fullname { get; private set; }
        public Guid Id { get; private set; }

        public bool IsAdult { get; private set; }

        public bool CanCome { get; private set; }

        public Guid? StarterChoice { get; private set; }

        public Guid? MainChoice { get; private set; }

        public Guid? DessertChoice { get; private set; }

        public bool HasReplied { get; private set; }
    }
}