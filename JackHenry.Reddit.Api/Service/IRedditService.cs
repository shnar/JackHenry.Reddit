using JackHenry.Reddit.Models;

namespace JackHenry.Reddit.Api.Service
{
	public interface IRedditService
	{
		IEnumerable<PostInfo> GetMostPosts();
		IEnumerable<UserInfo> GetMostUsers();
	}
}
