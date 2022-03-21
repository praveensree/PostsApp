using Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Server.Repository;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPostController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        public SocialPostController(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        // GET: api/SocialPost
        [HttpGet]
        public async Task<IActionResult> GetSocialPost()
        {
            //TODO: Have to write logic here
            try
            {
                var response = await Task.FromResult(_postRepository.GetSocialPost());
                return Ok(response);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/SocialPost/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSocialPostById(int id)
        {
            try
            {
                var response = await Task.FromResult(_postRepository.GetSocialPostById(id));
                return Ok(response);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/SocialPost
        [HttpPost]
        public async Task<IActionResult> CreateSocialPost([FromBody] Post post)
        {
            try
            {
                var response = await Task.FromResult(_postRepository.CreateSocialPost(post));
                return Ok(response);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSocialPost(int id, [FromBody] Post post)
        {
            try
            {
                var response = await Task.FromResult(_postRepository.UpdateSocialPost(id, post));
                return Ok(response);
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("LikesandHearts/{id}/{option}")]
        public async Task<IActionResult> UpdateSocialPostLike(int id, string option)
        {
            try
            {

                var response = await Task.FromResult(_postRepository.UpdateSocialPostLike(id, option));
                if (response >= 0)
                {
                    return Ok(response);
                }
                else
                {
                    return new StatusCodeResult(StatusCodes.Status500InternalServerError);
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

    }
}