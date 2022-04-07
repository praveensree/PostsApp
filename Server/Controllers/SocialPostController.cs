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
        private readonly IPostService _postService;
        public SocialPostController(IPostService postService)
        {
            _postService = postService;
        }

        // GET api/SocialPost
        [HttpGet]
        public async Task<IActionResult> GetSocialPost()
        {
            var response = await _postService.GetSocialPost();
            return Ok(response);
        }

        // GET api/SocialPost/1014
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialPostById(int id)
        {
            var response = await _postService.GetSocialPostById(id);
            return Ok(response);
        }

        // POST api/SocialPost
        [HttpPost]
        public async Task<IActionResult> CreateSocialPost([FromBody] Post post)
        {
            if (post != null && post.PostDescription != "" && post.PostName != "" && post.PostDescription != null && post.PostName != null)
            {
                var response = await _postService.CreateSocialPost(post);
                return Ok(response);
            }
            else
            {
                return BadRequest("please write about Post");
            }
        }

        // PUT api/SocialPost/1014
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialPost(int id, [FromBody] Post post)
        {
            if (post != null && post.PostDescription != "" && post.PostName != "")
            {
                var response = await _postService.UpdateSocialPost(id, post);
                return Ok(response);
            }
            else
            {
                return BadRequest("please write about Post");
            }
        }

        //put api/SocialPost/LikesandHearts/1014/unlike
        [HttpPut("LikesandHearts/{option}/{id}")]
        public async Task<IActionResult> UpdateSocialPostLikeHeart(int id, string option)
        {
            var response = await _postService.UpdateSocialPostLikeHeart(id, option);
            return Ok(response);
        }

    }
}