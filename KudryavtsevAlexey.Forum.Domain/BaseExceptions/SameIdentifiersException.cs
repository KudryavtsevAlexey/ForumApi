using System;

namespace KudryavtsevAlexey.Forum.Domain.BaseExceptions
{
    public abstract class SameIdentifiersException : Exception
    {
        public SameIdentifiersException(string message) : base(message)
        {
            
        }
    }
}
