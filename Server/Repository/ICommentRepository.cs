using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
   public interface ICommentRepository
    {
        List<Comment> GetCommentsByPostId(int id);
        Comment GetCommentByCommentId(int id);

        Comment CreateComment(Comment comment);
        Comment UpdateCommentById(int id, Comment comment);
    }
}
