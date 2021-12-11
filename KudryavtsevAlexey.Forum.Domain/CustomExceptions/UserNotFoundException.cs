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
        public UserNotFoundException(int userId)
            : base($"User with the identifier {userId} was not found")
        {

        }

        public UserNotFoundException(string userEmail) 
            : base($"User with the userEmail {userEmail} was not found")
        {
            
        }
    }
}
