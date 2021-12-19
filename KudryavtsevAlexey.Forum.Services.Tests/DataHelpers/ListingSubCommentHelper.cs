using KudryavtsevAlexey.Forum.Domain.Entities.Comments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.Services.Tests.DataHelpers
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
