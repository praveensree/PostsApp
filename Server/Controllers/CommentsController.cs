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
        public async Task<IActionResult> GetCommentsByPostId(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var CommentList = fb.Comments.Where(s => s.PostId == id).ToList();
                    return Ok(await Task.FromResult(CommentList));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("CommentbyId/{id}")]
        public async Task<IActionResult> GetCommentByCommentId(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {

                    var Comment = fb.Comments.Where(s => s.CommentId == id).First();
                    return Ok(await Task.FromResult(Comment));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    comment.CreatedDate = DateTime.Now;
                    comment.UpdatedDate = null;

                    fb.Comments.Add(comment);
                    fb.SaveChanges();
                    return Ok(await Task.FromResult(comment));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentById(int id, [FromBody] Comment comment)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Comments.First(x => x.CommentId == id);

                    update.CommentDetail = comment.CommentDetail;
                    update.UpdatedDate = DateTime.Now;
                    fb.SaveChanges();
                    return Ok(await Task.FromResult(fb.Comments.First(x => x.CommentId == id)));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            }
}

}

