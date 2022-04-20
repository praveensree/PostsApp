using PostApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using PostApp.Repository;
using PostApp.Services;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPostController : ControllerBase
    {
        private readonly ISocialPostService _postService;
        public SocialPostController(ISocialPostService postService)
        {
            _postService = postService;
        }

        // GET api/SocialPost
        [HttpGet]
        public async Task<IActionResult> GetSocialPost()
        {
            var response = await _postService.GetSocialPost();
            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        // GET api/SocialPost/1014
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialPostById(int id)
        {
            var response = await _postService.GetSocialPostById(id);
            if (response == null)
            {
                return NotFound("Invalid Id");
            }
            return Ok(response);
        }

        // POST api/SocialPost
        [HttpPost]
        public async Task<IActionResult> CreateSocialPost([FromBody] Post post)
        {
            var response = await _postService.CreateSocialPost(post);
            if (string.IsNullOrWhiteSpace(response.PostName))
            {
                return BadRequest("PostName is required");
            }
            else if (string.IsNullOrWhiteSpace(response.PostDescription))
            {
                return BadRequest("PostDescription is required");
            }
            return Ok(response);
        }

        // PUT api/SocialPost/1014
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialPost(int id, [FromBody] Post post)
        {
            var response = await _postService.UpdateSocialPost(id, post);
            if (string.IsNullOrWhiteSpace(response.PostDescription)) 
            {
                return BadRequest("PostDescription Required");
            }
            else if (string.IsNullOrWhiteSpace(response.PostName))
            {
                return BadRequest("PostName Required");
            }
                return Ok(response);
        }

        //put api/SocialPost/LikesandHearts/1014/unlike
        [HttpPut("LikesandHearts/{option}/{id}")]
        public async Task<IActionResult> UpdateSocialPostLikeHeart(int id, string option)
        {
            var response = await _postService.UpdateSocialPostLikeHeart(id, option);
            if (response == -1)
            { 
                return NotFound("Invalid Option");
            }
            else if (response == -2)
            {
                return NotFound("Invalid Id");
            }
            return Ok(response);
        }
    }
}