using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using System.Collections.Generic;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
	public static class ListingSubCommentHelper
	{
		public static List<ListingSubComment> GetMany()
		{
			var listListingMainComment = new List<ListingSubComment>()
			{
				new ListingSubComment() {Content = "ListingSubCommentContent2"},

				new ListingSubComment() {Content = "ListingSubCommentContent3"},

				new ListingSubComment() {Content = "ListingSubCommentContent4"},

				new ListingSubComment() {Content = "ListingSubCommentContent5"},
			};

			return listListingMainComment;
		}

		public static ListingSubComment GetOne()
		{
			return new ListingSubComment() { Content = "ListingSubCommentContent1" };
		}
	}
}
