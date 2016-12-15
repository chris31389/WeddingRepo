using System;

namespace Wedding.Domain.Core.Invites.Exceptions
{
    public class MealChoiceNotAllowedException : Exception
    {
        public MealChoiceNotAllowedException()
        {
        }

        public MealChoiceNotAllowedException(string message) : base(message)
        {
        }

        public MealChoiceNotAllowedException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}