using System;
using System.Dynamic;

namespace KudryavtsevAlexey.Forum.IntegrationTests.AuthorizationHelpers
{
	public static class JwtTokenHelper
	{
		public static dynamic GetCustomerToken()
		{
			dynamic data = new ExpandoObject();
			data.sub = Guid.NewGuid().ToString();
			return data;
		}
	}
}
