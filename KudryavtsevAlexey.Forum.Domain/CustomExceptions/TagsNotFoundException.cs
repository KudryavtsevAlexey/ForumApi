﻿using KudryavtsevAlexey.Forum.Domain.BaseEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.BaseExceptions;

namespace KudryavtsevAlexey.Forum.Domain.CustomExceptions
{
    public class TagsNotFoundException : CollectionNotFoundException
    {
        public TagsNotFoundException()
            :base("Tags were not found")
        {
            
        }
    }
}
