using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
    public static class ArticleSubCommentHelper
    {
	    public static List<ArticleSubComment> GetMany()
	    {
		    var listArticleSubComments = new List<ArticleSubComment>()
		    {
			    new ArticleSubComment() {Content = "ArticleSubCommentContent2"},

			    new ArticleSubComment() {Content = "ArticleSubCommentContent3"},

			    new ArticleSubComment() {Content = "ArticleSubCommentContent4"},

			    new ArticleSubComment() {Content = "ArticleSubCommentContent5"},
		    };

			return listArticleSubComments;
	    }

	    public static ArticleSubComment GetOne()
	    {
		    return new ArticleSubComment() {Content = "ArticleSubCommentContent1"};
	    }
    }
}
