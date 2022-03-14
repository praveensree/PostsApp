using Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialPostController : ControllerBase
    {
        // GET: api/SocialPost
        [HttpGet]
        public IActionResult GetSocialPost()
        {
            //TODO: Have to write logic here
            try
            {
                using (fbContext fb = new fbContext())
                {


                    return Ok(fb.Posts.ToList());
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // GET api/SocialPost/5
        [HttpGet("{id}")]
        public IActionResult GetSocialPostById(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {

                    return Ok(fb.Posts.First(x => x.PostId == id));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // POST api/SocialPost
        [HttpPost]
        public IActionResult CreateSocialPost([FromBody] Post post)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    post.CreatedDate = DateTime.Now;
                    post.UpdatedDate = null;
                    post.Likes = 0;
                    post.Hearts = 0;
                    fb.Posts.Add(post);
                    fb.SaveChanges();
                    return Ok(post);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }


        [HttpPut("{id}")]
        public IActionResult UpdateSocialPost(int id, [FromBody] Post post)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    update.PostName = post.PostName;
                    update.PostDescription = post.PostDescription;
                    update.UpdatedDate = DateTime.Now;
                    fb.SaveChanges();
                    return Ok(fb.Posts.First(x => x.PostId == id));
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("Like/{id}")]
        public void UpdateSocialPostLike([FromBody] string value, int id)
        {
            //TODO: Have to write logic here
        }

        [HttpPut("Heart/{id}")]
        public void UpdateSocialPostHeart([FromBody] string value, int id)
        {
            //TODO: Have to write logic here
        }

    }
}