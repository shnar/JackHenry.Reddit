using JackHenry.Reddit.Api.Service;
using JackHenry.Reddit.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JackHenry.Reddit.Api.Controllers
{
	/// <summary>
	/// A general Reddit service for Posts and data regarding redit posts.
	/// </summary>
	[Route("api/[controller]")]
	[ApiController]
	public class MostPostsController : ControllerBase
	{
		private IRedditService _redditService;

		public MostPostsController(IRedditService redditService)
		{
			_redditService = redditService;
		}

		/// <summary>
		/// Retrieve the top 10 posts with the most upvotes.
		/// </summary>
		/// <returns></returns>
		[HttpGet]
		public IEnumerable<PostInfo> Get()
		{
			var posts = _redditService.GetMostPosts();
			return posts.OrderByDescending(x => x.UpVotes).Take(10).ToList();
		}
	}
}
