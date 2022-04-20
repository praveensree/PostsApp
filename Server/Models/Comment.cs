using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace PostApp.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public string CommentDetail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
