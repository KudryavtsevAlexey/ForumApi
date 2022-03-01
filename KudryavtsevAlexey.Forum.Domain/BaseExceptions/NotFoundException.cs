using System;


namespace KudryavtsevAlexey.Forum.Domain.BaseExceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
