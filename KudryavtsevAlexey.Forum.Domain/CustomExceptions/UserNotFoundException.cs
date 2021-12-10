using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(int? id)
            : base($"User with the identifier {id} was not found")
        {

        }

        public UserNotFoundException(string? email) 
            : base($"User with the email {email} was not found")
        {
            
        }
    }
}
