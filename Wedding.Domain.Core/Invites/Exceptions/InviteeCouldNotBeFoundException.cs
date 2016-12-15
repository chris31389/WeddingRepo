using System;

namespace Wedding.Domain.Core.Invites.Exceptions
{
    public class InviteeCouldNotBeFoundException : Exception
    {
        public InviteeCouldNotBeFoundException()
        {
        }

        public InviteeCouldNotBeFoundException(string message) : base(message)
        {
        }

        public InviteeCouldNotBeFoundException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}