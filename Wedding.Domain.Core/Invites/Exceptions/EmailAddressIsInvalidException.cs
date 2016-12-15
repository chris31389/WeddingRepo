using System;

namespace Wedding.Domain.Core.Invites.Exceptions
{
    public class EmailAddressIsInvalidException : Exception
    {
        public EmailAddressIsInvalidException()
        {
        }

        public EmailAddressIsInvalidException(string message) : base(message)
        {
        }

        public EmailAddressIsInvalidException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}