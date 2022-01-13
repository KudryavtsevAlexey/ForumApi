using KudryavtsevAlexey.Forum.IntegrationTests.AuthorizationHelpers;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace KudryavtsevAlexey.Forum.IntegrationTests.Extensions
{
	public static class HttpClientExtension
	{
		private static string RegistrationUrl = "api/account/registration";
		private static string SignInUrl = "api/account/sign-in";

		public static async Task Register(this HttpClient client)
		{
			var registerUserDto = RegistrationHelper.CreateRegisterUserDto();
			var registrationJson = new StringContent(JsonConvert.SerializeObject(registerUserDto), Encoding.UTF8,
				"application/json");

			var result = await client.PostAsync(RegistrationUrl, registrationJson);

			await SignIn(client, registerUserDto.Email, registerUserDto.Password);
		}

		public static async Task SignIn(HttpClient client, string email, string password)
		{
			var signInUserDto = new SignInUserDto(Email: email, Password: password);
			var signInJson = new StringContent(JsonConvert.SerializeObject(signInUserDto), Encoding.UTF8, "application/json");

			var result = await client.PostAsync(SignInUrl, signInJson);

			dynamic data = JwtTokenHelper.GetCustomerToken();
			client.SetFakeBearerToken((object)data);
		}
	}
}
