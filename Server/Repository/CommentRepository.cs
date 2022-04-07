using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
    public class CommentRepository : ICommentRepository
    {
        private readonly fbContext context;
        public CommentRepository(fbContext context)
        {
            this.context = context;
        }

        public async Task<Comment> Insert(Comment comment)
        {
            try
            {
                comment.CreatedDate = DateTime.Now;
                comment.UpdatedDate = null;
                await context.Comments.AddAsync(comment);
                await context.SaveChangesAsync();
                return comment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> GetByCommentId(int id)
        {
            try
            {
                var Comment = await context.Comments.Where(s => s.CommentId == id).FirstAsync();
                return Comment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Comment>> GetByPostId(int id)
        {
            try
            {
                var CommentList = await context.Comments.Where(s => s.PostId == id).ToListAsync();
                return CommentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Comment> Update(int id, Comment comment)
        {
            try
            {
                var update = await context.Comments.FirstAsync(x => x.CommentId == id);
                update.CommentDetail = comment.CommentDetail;
                update.UpdatedDate = DateTime.Now;
                await context.SaveChangesAsync();
                return await context.Comments.FirstAsync(x => x.CommentId == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
