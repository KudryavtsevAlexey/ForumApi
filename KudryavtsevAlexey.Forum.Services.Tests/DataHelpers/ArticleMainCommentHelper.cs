using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
{
	public static class ArticleMainCommentHelper
    {
	    public static List<ArticleMainComment> GetMany()
	    {
		    var listArticleMainComments = new List<ArticleMainComment>()
		    {
			    new ArticleMainComment() {Content = "ArticleMainCommentContent2"},

			    new ArticleMainComment() {Content = "ArticleMainCommentContent3"},

			    new ArticleMainComment() {Content = "ArticleMainCommentContent4"},

			    new ArticleMainComment() {Content = "ArticleMainCommentContent5"},
		    };

			return listArticleMainComments;
	    }

	    public static ArticleMainComment GetOne()
	    {
		    return new ArticleMainComment() {Content = "ArticleMainCommentContent1" };
	    }
    }
}
