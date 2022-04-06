using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
   public interface ICommentRepository
    {
        List<Comment> GetByPostId(int id);
        Comment GetByCommentId(int id);

        Comment Insert(Comment comment);
        Comment Update(int id, Comment comment);
    }
}
