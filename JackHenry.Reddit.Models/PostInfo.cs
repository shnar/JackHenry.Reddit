using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JackHenry.Reddit.Models
{
    /// <summary>
    /// General information of a reddit post
    /// </summary>
	public class PostInfo
	{
        /// <summary>
        /// The title of the reddit post
        /// </summary>
        public string Title { get; set; } = string.Empty;

        /// <summary>
        /// The number of up votes this post has
        /// </summary>
        public int UpVotes { get; set; }
    }
}
