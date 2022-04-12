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

        public async Task<Comment> CreateComment(Comment comment)
        {
            try
            {
                return await _commentRepository.Insert(comment);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> GetCommentByCommentId(int id)
        {
            try
            {
                return await _commentRepository.GetByCommentId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Comment>> GetCommentsByPostId(int id)
        {
            try
            {
                return await _commentRepository.GetByPostId(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> UpdateCommentById(int id, Comment comment)
        {
            try
            {
                return await _commentRepository.Update(id, comment);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
