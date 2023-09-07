using JackHenry.Reddit.Models;

namespace JackHenry.Reddit.Web.Models
{
	public class HomeViewModel
	{
        public List<UserInfo> UserInfos { get; set; }
        public List<PostInfo> PostInfos { get; set; }
    }
}
