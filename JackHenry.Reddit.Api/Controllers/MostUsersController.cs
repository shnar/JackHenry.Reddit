using JackHenry.Reddit.Api.Service;
using JackHenry.Reddit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JackHenry.Reddit.Api.Controllers
{
	/// <summary>
	/// A service for general user information from reddit
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class MostUsersController : ControllerBase
	{
		private IRedditService _redditService;

		public MostUsersController(IRedditService redditService)
		{
			_redditService = redditService;
		}

		/// <summary>
		/// Retrieve the top 10 users with the number of posts created in this subreddit.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<UserInfo> Get()
		{
			var users = _redditService.GetMostUsers();
			return users.OrderByDescending(x => x.NumberOfPosts).ToList();
		}

	}
}
