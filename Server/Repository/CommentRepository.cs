using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
    public class CommentRepository : ICommentRepository
    {
        public Comment CreateComment(Comment comment)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    comment.CreatedDate = DateTime.Now;
                    comment.UpdatedDate = null;

                    fb.Comments.Add(comment);
                    fb.SaveChanges();
                    return comment;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Comment GetCommentByCommentId(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {

                    var Comment = fb.Comments.Where(s => s.CommentId == id).First();
                    return Comment;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Comment> GetCommentsByPostId(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var CommentList = fb.Comments.Where(s => s.PostId == id).ToList();
                    return CommentList;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Comment UpdateCommentById(int id, Comment comment)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Comments.First(x => x.CommentId == id);

                    update.CommentDetail = comment.CommentDetail;
                    update.UpdatedDate = DateTime.Now;
                    fb.SaveChanges();
                    return fb.Comments.First(x => x.CommentId == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
