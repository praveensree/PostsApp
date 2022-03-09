using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        // GET: api/<CommentsController>
        [HttpGet("{id}")]
        public IEnumerable<string> GetCommentsByPostId()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<CommentsController>/5
        [HttpGet("commentId/{id}")]
        public string GetCommentByCommentId(int id)
        {
            return "value";
        }

        // POST api/<CommentsController>
        [HttpPost]
        public void CreateComment([FromBody] string value)
        {
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public void UpdateCommentById([FromBody] string value, int id)
        {
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public void DeleteCommentById(int id)
        {
        }
    }
}