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
        [HttpGet]
        public IActionResult GetAllComments()
        {
            try
            {
                using (fbContext fb = new fbContext())
                {

                    return Ok(fb.Comments.ToList());
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetCommentsById(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {

                    return Ok(fb.Comments.First(x => x.CommentId == id));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public IActionResult AddComment([FromBody] Comment comment)
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
        public IActionResult ModifyComment(int id, [FromBody] Comment comment)
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




