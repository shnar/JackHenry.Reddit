namespace JackHenry.Reddit.Models
{
    /// <summary>
    /// General information on a reddit user.
    /// </summary>
    public class UserInfo
    {
        /// <summary>
        /// the user's name of the information
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// The number of posts this user has made.
        /// </summary>
        public int NumberOfPosts { get; set; }
    }
}