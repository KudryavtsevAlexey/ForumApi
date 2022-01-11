using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseEntities;

namespace KudryavtsevAlexey.Forum.Domain.Entities
{
    public class Subscriber
    {
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime SubscribedAt { get; set; } = DateTime.UtcNow.Date;
    }
}
