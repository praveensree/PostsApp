using PostApp.Models;
using PostApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Services
{
    public class CommentService:ICommentService
    {
        private readonly ICommentRepository _commentRepository;
        public CommentService(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public Task<Comment> CreateComment(Comment comment)
        {
            try
            {
                return _commentRepository.Insert(comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public Task<Comment> GetCommentByCommentId(int id)
        {
            return _commentRepository.GetByCommentId(id);

        }

        public Task<List<Comment>> GetCommentsByPostId(int id)
        {
            return _commentRepository.GetByPostId(id);

        }

        public Task<Comment> UpdateCommentById(int id, Comment comment)
        {
            return _commentRepository.Update(id, comment);

        }
    }
}
