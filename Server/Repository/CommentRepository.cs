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
        private readonly PostAppContext context;
        public CommentRepository(PostAppContext context)
        {
            this.context = context;
        }

        public async Task<Comment> Insert(Comment comment)
        {
            if (string.IsNullOrWhiteSpace(comment.CommentDetail))
            {
                comment.CreatedDate = DateTime.Now;
                comment.UpdatedDate = null;
                await context.Comments.AddAsync(comment);
                await context.SaveChangesAsync();
                return comment;
            }
            else
            {
                throw new ArgumentException(nameof(comment.CommentDetail));
            }
        }

        public async Task<Comment> GetByCommentId(int id)
        {

            var Comment = await context.Comments.Where(s => s.CommentId == id).FirstOrDefaultAsync();
            if (Comment != null)
            {
                return Comment;
            }
            else
            {
                throw new ArgumentException(nameof(id));
            }
        }

        public async Task<List<Comment>> GetByPostId(int id)
        {

            var CommentList = await context.Comments.Where(s => s.PostId == id).ToListAsync();
            if (CommentList != null)
            {
                return CommentList;
            }
            else
            {
                throw new ArgumentException(nameof(id));
            }
        }

        public async Task<Comment> Update(int id, Comment comment)
        {
            var Update = await context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if (Update != null)
            {

                if (string.IsNullOrWhiteSpace(comment.CommentDetail))
                {
                    throw new ArgumentException(nameof(comment.CommentDetail));
                }
                else
                {
                    Update.CommentDetail = comment.CommentDetail;
                    Update.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();
                    return await context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
                }
            }
            else
            {
                throw new ArgumentException(nameof(comment.CommentId));
            }
        }
    }
}
