using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Server.Repository;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentRepository _commentRepository;
        public CommentsController(ICommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentsByPostId(int id)
        {
            try
            {
                var response = await Task.FromResult(_commentRepository.GetCommentsByPostId(id));
                return Ok(response);
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
                var response = await Task.FromResult(_commentRepository.GetCommentByCommentId(id));
                return Ok(response);
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
                var response = await Task.FromResult(_commentRepository.CreateComment(comment));
                return Ok(response);
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
                var response = await Task.FromResult(_commentRepository.UpdateCommentById(id, comment));
                return Ok(response);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            }
}

}

