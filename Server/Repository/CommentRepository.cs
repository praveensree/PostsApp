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
        public Comment Insert(Comment comment)
        {
            try
            {
                    comment.CreatedDate = DateTime.Now;
                    comment.UpdatedDate = null;
                    context.Comments.Add(comment);
                    context.SaveChangesAsync();
                    return comment;
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Comment GetByCommentId(int id)
        {
            try
            {

                    var Comment = context.Comments.Where(s => s.CommentId == id).First();
                    return Comment;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comment> GetByPostId(int id)
        {
            try
            {
                    var CommentList = context.Comments.Where(s => s.PostId == id).ToList();
                    return CommentList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Comment Update(int id, Comment comment)
        {
            try
            {
                    var update = context.Comments.First(x => x.CommentId == id);

                    update.CommentDetail = comment.CommentDetail;
                    update.UpdatedDate = DateTime.Now;
                    context.SaveChanges();
                    return context.Comments.First(x => x.CommentId == id);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
