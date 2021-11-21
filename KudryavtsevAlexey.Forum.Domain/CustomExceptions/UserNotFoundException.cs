using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int id)
            : base($"User with the identifier {id} was not found")
        {

        }
    }
}
