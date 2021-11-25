using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class TagsNotFoundException : Exception
    {
        public TagsNotFoundException()
            :base("Tags were not found")
        {
            
        }
    }
}
