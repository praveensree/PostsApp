using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
   public interface ICommentRepository
    {
        Task<List<Comment>> GetByPostId(int id);
        Task<Comment> GetByCommentId(int id);

        Task<Comment> Insert(Comment comment);
        Task<Comment> Update(int id, Comment comment);
    }
}
