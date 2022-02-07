using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Domain.Entities;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DataHelpers
{
    public static class ListingHelper
    {
	    public static List<Listing> GetMany()
	    {
		    var listListings = new List<Listing>()
		    {
				new Listing() {Category = "ListingCategory2", ShortDescription = "ShortListingDescription2", Title = "ListingTitle2"},

				new Listing() {Category = "ListingCategory3", ShortDescription = "ShortListingDescription3", Title = "ListingTitle3"},

				new Listing() {Category = "ListingCategory4", ShortDescription = "ShortListingDescription4", Title = "ListingTitle4"},

				new Listing() {Category = "ListingCategory5", ShortDescription = "ShortListingDescription5", Title = "ListingTitle5"},
		    };

			return listListings;
	    }

	    public static Listing GetOne()
	    {
		    return new Listing()
			    {Category = "ListingCategory1", ShortDescription = "ShortListingDescription1", Title = "ListingTitle1"};
	    }
    }
}
