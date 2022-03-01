using System.Threading.Tasks;
using KudryavtsevAlexey.Forum.Services.ServiceManager;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KudryavtsevAlexey.Forum.Api.Controllers
{
	[ApiController]
	[Authorize]
	[Route("api/subscriber")]
	public class SubscriberController : ControllerBase
	{
		private readonly IServiceManager _serviceManager;

		public SubscriberController(IServiceManager serviceManager)
		{
			_serviceManager = serviceManager;
		}

		[HttpGet]
		[Route("{id}")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetSubscriberById([FromRoute] int id)
		{
			var subscriber = await _serviceManager.SubscriberService.GetSubscriberById(id);

			return Ok(subscriber);
		}

		/// <summary>
		/// Returns user subscribers
		/// </summary>
		/// <returns>User subscribers</returns>
		/// <response code="200">Returns subscribers</response>
		/// <response code="401">If user not authorized</response>
		/// <response code="404">If subscribers not found</response>
		[HttpGet]
		[Route("{id}/subscribers")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status401Unauthorized)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> GetUserSubscribers([FromRoute] int id)
		{
			var subscribers = await _serviceManager.UserService.GetUserSubscribers(id);

			if (subscribers.Count == 0)
			{
				return NotFound();
			}

			return Ok(subscribers);
		}

		/// <summary>
		/// Creates subscriber
		/// </summary>
		/// <returns>No content if subscriber created</returns>
		/// <response code="204">If subscriber created</response>
		/// <response code="401">If user not authorized</response>
		/// <response code="404">If user or subscriber not found</response>
		[HttpPost]
		[Route("start-sub")]
		[ProducesResponseType(StatusCodes.Status204NoContent)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> SubscribeUser([FromQuery(Name = "u")] int userId, [FromQuery(Name = "s")] int subscriberId)
		{
			await _serviceManager.SubscriberService.CreateSubscriber(userId, subscriberId);
			
			return NoContent();
		}

		/// <summary>
		/// Deletes subscriber
		/// </summary>
		/// <returns>No content if subscriber deleted</returns>
		/// <response code="204">If subscriber deleted</response>
		/// <response code="401">If user not authorized</response>
		/// <response code="404">If subscriber user or subscriber not found</response>
		[HttpDelete]
		[Route("stop-sub")]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		public async Task<IActionResult> StopSubscribe([FromQuery(Name = "u")] int userId, [FromQuery(Name = "s")] int subscriberId)
		{
			await _serviceManager.SubscriberService.DeleteSubscriber(userId, subscriberId);
			
			return NoContent();
		}
	}
}
