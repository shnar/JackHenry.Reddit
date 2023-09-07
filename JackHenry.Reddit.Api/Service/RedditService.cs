using JackHenry.Reddit.Models;
using Reddit.Controllers;
using System.Data;
using r = Reddit;

namespace JackHenry.Reddit.Api.Service
{
	public class RedditService : IRedditService
	{
		private string subredditName = "lotr";

		private r.RedditClient _reddit;
		private List<Post> _posts;
		private List<User> _users = new List<User>();

		public RedditService()
		{
			InitReddit();

			//start timer to poll reddit
			var startTimeSpan = TimeSpan.Zero;
			var periodTimeSpan = TimeSpan.FromMinutes(1);

			var timer = new System.Threading.Timer((e) =>
			{
				UpdatePosts();
				UpdateUsers();

			}, null, startTimeSpan, periodTimeSpan);
		}

		private void InitReddit()
		{
			//TODO: Move these magic strings to configurations
			_reddit = new r.RedditClient("CPMOB1XM3dgj6P9PynTf8A", "W4dqrp3iQzqcewAEbx07jOMKGtlFWQ");

		}

		private void UpdatePosts()
		{
			var subreddit = _reddit.Subreddit(subredditName).About();
			_posts = subreddit.Posts.Top.Take(10).ToList();

		}

		private void UpdateUsers()
		{
			if (_posts == null) UpdatePosts();

			_users.Clear();
			foreach(var post in _posts)
			{
				string userName = post.Author;
				var users = _reddit.SearchUsers(new r.Inputs.Search.SearchGetSearchInput() { before = userName, after = userName });
				if (users != null && users.Count > 0)
					_users.Add(users[0]);
			}
		}

		public IEnumerable<PostInfo> GetMostPosts()
		{
			var posts = new List<PostInfo>();

			foreach(var redditPost in _posts)
			{
				var post = new PostInfo();
				post.Title = redditPost.Title;
				post.UpVotes = redditPost.UpVotes;
				posts.Add(post);
			}

			return posts;
		}

		public IEnumerable<UserInfo> GetMostUsers()
		{
			var users = new List<UserInfo>();

			foreach (var redditUser in _users)
			{
				var user = new UserInfo();
				user.UserName = redditUser.Name;
				user.NumberOfPosts = redditUser.PostHistory.Count;
				users.Add(user);
			}

			return users;
		}
	}
}
