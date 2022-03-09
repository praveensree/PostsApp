using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        [HttpGet("{id}")]
        public IActionResult GetCommentsByPostId(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var CommentList = fb.Comments.Where(s => s.PostId == id).ToList();
                    return Ok(CommentList);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("CommentbyId/{id}")]
        public IActionResult GetCommentByCommentId(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {

                    var Comment = fb.Comments.Where(s => s.CommentId == id).First();
                    return Ok(Comment);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult CreateComment([FromBody] Comment comment)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    comment.CreatedDate = DateTime.Now;
                    comment.UpdatedDate = null;

                    fb.Comments.Add(comment);
                    fb.SaveChanges();
                    return Ok(comment);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateCommentById(int id, [FromBody] Comment comment)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Comments.First(x => x.CommentId == id);

                    update.CommentDetail = comment.CommentDetail;
                    update.UpdatedDate = DateTime.Now;
                    fb.SaveChanges();
                    return Ok(fb.Comments.First(x => x.CommentId == id));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteComments(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var delete = fb.Comments.First(x => x.CommentId == id);

                    fb.Comments.Remove(delete);
                    fb.SaveChanges();
                    return Ok("Deleted");
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}




