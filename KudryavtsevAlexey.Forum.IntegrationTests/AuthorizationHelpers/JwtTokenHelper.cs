using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
