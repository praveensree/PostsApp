using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if (string.IsNullOrWhiteSpace(comment.CommentDetail) || comment.PostId == null)
            {
                return comment;
            }
            else
            {
                if (context.Comments.Any(o => o.PostId == comment.PostId))
                {
                    comment.CreatedDate = DateTime.Now;
                    comment.UpdatedDate = null;
                    await context.Comments.AddAsync(comment);
                    var Po = await context.SaveChangesAsync() > 0;
                    return Po ? comment : throw new Exception("Unable to process");
                }
                else
                {
                    comment.CommentId = -1;
                    return comment;
                }
            }
        }

        public async Task<Comment> GetByCommentId(int id)
        {
            var Comment = await context.Comments.Where(s => s.CommentId == id).SingleOrDefaultAsync();
            return Comment;
        }

        public async Task<List<Comment>> GetByPostId(int id)
        {
            var CommentList = await context.Comments.Where(s => s.PostId == id).ToListAsync();
            if (context.Posts.Any(o => o.PostId == id))
            {
                return CommentList;
            }
            else
            {
                return CommentList;
            }
        }

        public async Task<Comment> Update(int id, Comment comment)
        {
            var Update = await context.Comments.FirstOrDefaultAsync(x => x.CommentId == id);
            if (Update != null)
            {
                if (string.IsNullOrWhiteSpace(comment.CommentDetail))
                {
                    return comment;
                }
                else
                {
                    Update.CommentDetail = comment.CommentDetail;
                    Update.UpdatedDate = DateTime.Now;
                    var Po = await context.SaveChangesAsync() > 0;
                    return Po ? await context.Comments.FirstOrDefaultAsync(x => x.CommentId == id) : throw new Exception("Unable to process");
                }
            }
            else
            {
                comment.CommentId = -1;
                return comment;
            }
        }
    }
}
