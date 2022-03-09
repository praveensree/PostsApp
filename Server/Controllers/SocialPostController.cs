﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPostController : ControllerBase
    {
        // GET: api/SocialPost
        [HttpGet]
        public IEnumerable<string> GetAllPosts()
        {
            //TODO: Have to write logic here
            return new string[] { "value1", "value2" };
        }

        // GET api/SocialPost/5
        [HttpGet("{id}")]
        public string GetPostById(int id)
        {
            //TODO: Have to write logic here
            return "value";
        }

        // POST api/SocialPost
        [HttpPost]
        public void CreateNewPost([FromBody] string value)
        {
            //TODO: Have to write logic here
        }

        // PUT api/SocialPost/5
        [HttpPut("{id}")]
        public void UpdatePostById( [FromBody] string value, int id)
        {
            //TODO: Have to write logic here
        }

        [HttpPut("Like/{id}")]
        public void UpdateLike([FromBody] string value, int id)
        {
            //TODO: Have to write logic here
        }

        [HttpPut("Heart/{id}")]
        public void UpdateHeart([FromBody] string value, int id)
        {
            //TODO: Have to write logic here
        }

        // DELETE api/SocialPost/5
        [HttpDelete("{id}")]
        public void DeletePostById(int id)
        {
            //TODO: Have to write logic here
        }
    }
}