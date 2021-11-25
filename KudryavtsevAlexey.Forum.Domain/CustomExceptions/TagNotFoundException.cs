using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class TagNotFoundException : NotFoundException
    {
        public TagNotFoundException(int id)
            :base($"$Tag with the identifier {id} was not found")
        {
            
        }
    }
}
