using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class UserSubscriber
    {
        public int SubscriberId { get; set; }

        public int UserId { get; set; }

        public Subscriber Subscriber { get; set; }

        public User User { get; set; }
    }
}
