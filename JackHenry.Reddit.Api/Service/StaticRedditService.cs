using JackHenry.Reddit.Models;
using System;

namespace JackHenry.Reddit.Api.Service
{
	public class StaticRedditService : IRedditService
	{
		public IEnumerable<UserInfo> GetMostUsers()
		{
			var random = new Random();
			var results = new List<UserInfo>();
			results.Add(new UserInfo() { UserName = "Tacitus", NumberOfPosts = random.Next(1, 100) });
			results.Add(new UserInfo() { UserName = "shnar", NumberOfPosts = random.Next(1, 100) });
			results.Add(new UserInfo() { UserName = "CrysisRequiem", NumberOfPosts = random.Next(1, 100) });
			results.Add(new UserInfo() { UserName = "Theobold_von", NumberOfPosts = random.Next(1, 100) });
			results.Add(new UserInfo() { UserName = "Happy-Pollution", NumberOfPosts = random.Next(1, 100) });
			results.Add(new UserInfo() { UserName = "National-Salt", NumberOfPosts = random.Next(1, 100) });
			results.Add(new UserInfo() { UserName = "Mountain_Ad", NumberOfPosts = random.Next(1, 100) });
			return results;
		}

		public IEnumerable<PostInfo> GetMostPosts()
		{
			var random = new Random();
			var results = new List<PostInfo>();
			results.Add(new PostInfo() { Title = "Unexpected find at my university", UpVotes = random.Next(1, 100) });
			results.Add(new PostInfo() { Title = "They should have called it Gollumaide", UpVotes = random.Next(1, 100) });
			results.Add(new PostInfo() { Title = "DragonCon2023 made my dreams come true", UpVotes = random.Next(1, 100) });
			results.Add(new PostInfo() { Title = "Made this for my friends", UpVotes = random.Next(1, 100) });
			return results;
		}
	}
}
