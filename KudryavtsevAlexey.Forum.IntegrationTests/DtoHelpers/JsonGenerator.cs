using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace KudryavtsevAlexey.Forum.IntegrationTests.DtoHelpers
{
	public static class JsonGenerator
	{
		public static StringContent GetStringContent<T>(T dto) where T : class
		{
			return new StringContent(JsonConvert.SerializeObject(dto), Encoding.UTF8, "application/json");
		}
	}
}
