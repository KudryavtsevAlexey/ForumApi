using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.BaseExceptions
{
    public abstract class CollectionNotFoundException : Exception
    {
        protected CollectionNotFoundException(string message) : base(message)
        {

        }
    }
}
