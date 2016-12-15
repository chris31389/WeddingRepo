namespace Wedding.Domain.Core.Invites
{
    public class Rsvp : Member<Invitee>
    {
        protected Rsvp()
        {
        }

        public Rsvp(Invitee parent, bool rsvpResponse) : base(parent)
        {
            CanCome = rsvpResponse;
        }

        public bool CanCome { get; set; }

    }
}