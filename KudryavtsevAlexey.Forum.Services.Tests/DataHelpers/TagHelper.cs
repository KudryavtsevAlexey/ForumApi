using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
{
    public static class TagHelper
    {
	    public static List<Tag> GetMany()
	    {
		    var listTags = new List<Tag>()
		    {
				new Tag() {Name = "Tag2"},

				new Tag() {Name = "Tag3"},

				new Tag() {Name = "Tag4"},

				new Tag() {Name = "Tag5"},
		    };

			return listTags;
	    }

	    public static Tag GetOne()
	    {
		    return new Tag() {Name = "Tag1"};
	    }
    }
}
