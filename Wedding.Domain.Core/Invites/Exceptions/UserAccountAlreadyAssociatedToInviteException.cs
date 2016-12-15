using System;

namespace Wedding.Domain.Core.Invites.Exceptions
{
    public class UserAccountAlreadyAssociatedToInviteException : Exception
    {
        public UserAccountAlreadyAssociatedToInviteException()
        {
        }

        public UserAccountAlreadyAssociatedToInviteException(string message) : base(message)
        {
        }

        public UserAccountAlreadyAssociatedToInviteException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}