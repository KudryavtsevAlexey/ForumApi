using System;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Api;
using KudryavtsevAlexey.Forum.Domain.Entities;
using KudryavtsevAlexey.Forum.Infrastructure.Database;
using KudryavtsevAlexey.Forum.IntegrationTests.AuthorizationHelpers;
using KudryavtsevAlexey.Forum.IntegrationTests.WebApplicationFactory;
using KudryavtsevAlexey.Forum.Services.Dtos.Organization;
using KudryavtsevAlexey.Forum.Services.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Newtonsoft.Json;
using Xunit;

namespace KudryavtsevAlexey.Forum.IntegrationTests.CrudIntegrationTests
{
	public class CrudTests : IClassFixture<CustomWebApplicationFactory<Startup>>
	{
		private readonly CustomWebApplicationFactory<Startup> _factory;
		private readonly HttpClient _client;

		public CrudTests(CustomWebApplicationFactory<Startup> factory)
		{
			_factory = factory;

			_client = _factory.CreateClient(new WebApplicationFactoryClientOptions()
			{
				AllowAutoRedirect = false
			});
		}

		[Theory]
		[InlineData("api/account/registration", "api/account/sign-in", "api/organization/create", "api/organization/find/name", "api/organization/update", "api/organization/")]
		public async Task OrganizationCrudTest(string registrationUrl, string signInUrl, string createUrl, string getUrl, string updateUrl, string deleteUrl)
		{
			// arrange
			var registerUserDto = new RegisterUserDto(Email: "Email@test.com", Password: "Password123",
				ConfirmedPassword: "Password123", OrganizationName: "Organization1", Location: "Location",
				UserName: "UserName", Name: "Name");
			var registrationJson = new StringContent(JsonConvert.SerializeObject(registerUserDto), Encoding.UTF8,
				"application/json");

			var signInUserDto = new SignInUserDto(Email: registerUserDto.Email, Password: registerUserDto.Password);
			var signInJson = new StringContent(JsonConvert.SerializeObject(signInUserDto), Encoding.UTF8, "application/json");

			var createOrganizationDto = new CreateOrganizationDto(Name: "CreatedOrganizationName");
			var createOrganizationJson = new StringContent(JsonConvert.SerializeObject(createOrganizationDto), Encoding.UTF8, "application/json");

			var organizationName = createOrganizationDto.Name;
			var organizationId = 6;

			var updateOrganizationDto = createOrganizationDto with { Name = "UpdatedName" };
			var updateOrganizationJson = new StringContent(JsonConvert.SerializeObject(updateOrganizationDto), Encoding.UTF8, "application/json");

			// act
			var registrationResponseMessage = await _client.PostAsync(registrationUrl, registrationJson);

			var signInResponseMessage = await _client.PostAsync(signInUrl, signInJson);
			dynamic data = JwtTokenHelper.GetCustomerToken();
			_client.SetFakeBearerToken((object)data);

			var postResponseMessage = await _client.PostAsync(createUrl, createOrganizationJson);
			var getResponseMessage = await _client.GetAsync(getUrl + $"?organizationName={organizationName}");
			var patchResponseMessage = await _client.PatchAsync(updateUrl + $"?id={organizationId}", updateOrganizationJson);
			var deleteResponseMessage = await _client.DeleteAsync(deleteUrl + $"{organizationId}/delete");
			
			// assert
			Assert.True(registrationResponseMessage.StatusCode == HttpStatusCode.OK);
			Assert.True(signInResponseMessage.StatusCode == HttpStatusCode.OK);
			Assert.True(postResponseMessage.StatusCode == HttpStatusCode.OK);
			Assert.True(getResponseMessage.StatusCode == HttpStatusCode.OK);
			Assert.True(patchResponseMessage.StatusCode == HttpStatusCode.OK);
			Assert.True(deleteResponseMessage.StatusCode == HttpStatusCode.OK);
		}
	}
}
