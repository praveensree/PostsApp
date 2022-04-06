using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Services
{
   public interface ICommentService
    {
        Task<List<Comment>> GetCommentsByPostId(int id);
        Task<Comment> GetCommentByCommentId(int id);

        Task<Comment> CreateComment(Comment comment);
        Task<Comment> UpdateCommentById(int id, Comment comment);
    }
}
