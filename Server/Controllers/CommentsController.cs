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
            return Ok(response);
           
        }

        //GET api/Comments/CommentbyId/1014
        [HttpGet("CommentbyId/{id}")]
        public async Task<IActionResult> GetCommentByCommentId(int id)
        {
            var response = await _commentService.GetCommentByCommentId(id);
            return Ok(response);
        }

        //POST api/Comments
        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] Comment comment)
        {
                var response = await _commentService.CreateComment(comment);
                return Ok(response);
        }

        //PUT api/Comments/1014
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCommentById(int id, [FromBody] Comment comment)
        {
           
                var response = await _commentService.UpdateCommentById(id, comment);
                return Ok(response);
        }
    }
}

