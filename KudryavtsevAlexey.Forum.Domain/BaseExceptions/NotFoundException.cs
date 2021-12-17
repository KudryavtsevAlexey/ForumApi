using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KudryavtsevAlexey.Forum.Domain.BaseExceptions
{
    public abstract class NotFoundException : Exception
    {
        protected NotFoundException(string message) : base(message)
        {

        }
    }
}
