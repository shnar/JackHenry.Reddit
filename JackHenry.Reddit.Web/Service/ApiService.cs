using JackHenry.Reddit.Models;
using JackHenry.Reddit.Utils;
using System.Runtime.CompilerServices;

namespace JackHenry.Reddit.Web.Service
{
	public static class ApiService
	{

		private static string ServiceUrl = "https://localhost:7292/api/";

		internal static async Task<List<PostInfo>> GetMostPosts()
		{
			var results = await HttpUtils.Get<List<PostInfo>>(ServiceUrl + "MostPosts");
			return results;
		}

		internal static async Task<List<UserInfo>> GetMostUsers()
		{
			var results = await HttpUtils.Get<List<UserInfo>>(ServiceUrl + "MostUsers");
			return results;
		}
	}
}
