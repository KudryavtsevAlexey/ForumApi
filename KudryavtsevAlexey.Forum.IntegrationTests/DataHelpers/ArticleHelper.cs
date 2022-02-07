using KudryavtsevAlexey.Forum.Domain.Entities;
using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
	public static class ArticleHelper
    {
	    public static List<Article> GetMany()
	    {
		    var listArticles = new List<Article>()
		    {
			    new Article()
			    {
				    Title = "ArticleTitle2", ShortDescription = "ShortArticleDescription2",
			    },

			    new Article()
			    {
				    Title = "ArticleTitle3", ShortDescription = "ShortArticleDescription3",
			    },

			    new Article()
			    {
				    Title = "ArticleTitle4", ShortDescription = "ShortArticleDescription4",
			    },

			    new Article()
			    {
				    Title = "ArticleTitle5", ShortDescription = "ShortArticleDescription5",
			    },
		    };

			return listArticles;
	    }

	    public static Article GetOne()
	    {
		    return new Article()
		    {
			    Title = "ArticleTitle1", ShortDescription = "ShortArticleDescription1"
		    };
	    }
    }
}
