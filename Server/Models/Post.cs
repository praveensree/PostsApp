using System;
using System.Collections.Generic;

#nullable disable

namespace Server.Models
{
    public partial class Post
    {
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public int PostId { get; set; }
        public string PostName { get; set; }
        public string PostDescription { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? Likes { get; set; }
        public int? Hearts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
