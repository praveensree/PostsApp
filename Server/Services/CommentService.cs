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
            return Task.FromResult(_commentRepository.Insert(comment));

        }

        public Task<Comment> GetCommentByCommentId(int id)
        {
            return Task.FromResult(_commentRepository.GetByCommentId(id));

        }

        public Task<List<Comment>> GetCommentsByPostId(int id)
        {
            return Task.FromResult(_commentRepository.GetByPostId(id));

        }

        public Task<Comment> UpdateCommentById(int id, Comment comment)
        {
            return Task.FromResult(_commentRepository.Update(id, comment));

        }
    }
}
