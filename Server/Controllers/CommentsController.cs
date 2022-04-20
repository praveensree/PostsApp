using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PostApp.Repository;
using PostApp.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        //GET api/Comments/1014
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByPostId(int id)
        {
            var response = await _commentService.GetCommentsByPostId(id);
            if (response.Count > 0)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Invalid Id");
            }
        }

        //GET api/Comments/CommentbyId/1014
        [HttpGet("CommentbyId/{id}")]
        public async Task<IActionResult> GetCommentByCommentId(int id)
        {
            var response = await _commentService.GetCommentByCommentId(id);
            if (response != null)
            {
                return Ok(response);
            }
            else
            {
                return NotFound("Invalid Id");
            }
        }

        //POST api/Comments
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
            var response = await _commentService.CreateComment(comment);
            if (response.CommentId < 0)
            {
                if (response.CommentId == -1)
                {
                    return NotFound("Invalid Id");
                }
                return NotFound("unable to process");
            }
            else if (string.IsNullOrWhiteSpace(response.CommentDetail))
            {
                return BadRequest("commentDetail Required");
            }
            else if (response.PostId == null)
            {
                return BadRequest("PostId Required");
            }
            return Ok(response);
        }

        //PUT api/Comments/1014
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentById(int id, [FromBody] Comment comment)
        {
            var response = await _commentService.UpdateCommentById(id, comment);
            if (string.IsNullOrWhiteSpace(response.CommentDetail))
            {
                return BadRequest("Commentdetail Required");
            }
            else if (response.CommentId < 0)
            {
                if (response.CommentId == -1)
                {
                    return NotFound("Invalid Id");
                }
                return NotFound("unable to process");
            }
            return Ok(response);
        }
    }
}

