using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Tests.FakeEntities
{
    public class FakeApplicationUser : ApplicationUser
    {
        public string Password { get; set; }
    }
}
