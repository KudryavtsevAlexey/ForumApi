using System.Collections.Generic;
using KudryavtsevAlexey.Forum.Domain.Entities.Comments;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
    public static class ListingMainCommentHelper
    {
	    public static List<ListingMainComment> GetMany()
	    {
		    var listListingMainComment = new List<ListingMainComment>()
		    {
			    new ListingMainComment() {Content = "ListingMainCommentContent2"},

			    new ListingMainComment() {Content = "ListingMainCommentContent3"},

			    new ListingMainComment() {Content = "ListingMainCommentContent4"},

			    new ListingMainComment() {Content = "ListingMainCommentContent5"},
		    };

			return listListingMainComment;
	    }

	    public static ListingMainComment GetOne()
	    {
		    return new ListingMainComment() {Content = "ListingMainCommentContent1"};
	    }
	}
}
