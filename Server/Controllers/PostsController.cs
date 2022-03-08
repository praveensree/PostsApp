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
    public class PostsController : ControllerBase
    {
        // GET: api/<PostsController>
        [HttpGet]
        public IActionResult GetAllPosts()
        {
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

        // GET api/<PostsController>/5
        [HttpGet("{id}")]
        public IActionResult GetPostsById(int id)
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

        // POST api/<PostsController>
        [HttpPost]
        public IActionResult AddNewPost([FromBody] Post post)
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

        // PUT api/<PostsController>/5
        [HttpPut("{id}")]
        public IActionResult ModifyExistingPost(int id, [FromBody] Post post)
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
        [HttpPut("likes/{id}")]
        public IActionResult AddLike(int id, [FromBody] Post post)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    update.Likes = post.Likes + 1;
                    fb.SaveChanges();
                    return Ok(update.Likes);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
        [HttpPut("dislikes/{id}")]
        public IActionResult UnLike(int id, [FromBody] Post post)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    if (post.Likes != 0)
                    {
                        update.Likes = post.Likes - 1;
                        fb.SaveChanges();

                        return Ok(update.Likes);
                    }
                    return Ok(0);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("hearts/{id}")]
        public IActionResult AddHeart(int id, [FromBody] Post post)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    update.Hearts = post.Hearts + 1;
                    fb.SaveChanges();
                    return Ok(update.Hearts);
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut("dishearts/{id}")]
        public IActionResult RemoveHeart(int id, [FromBody] Post post)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    if (post.Hearts != 0)
                    {
                        update.Hearts = post.Hearts - 1;
                        fb.SaveChanges();
                        return Ok(update.Hearts);
                    }

                    return Ok(0);


                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }

        // DELETE api/<PostsController>/5
        [HttpDelete("{id}")]
        public IActionResult RemovePost(int id)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    var delete = fb.Posts.First(x => x.PostId == id);
                    fb.Posts.Remove(delete);
                    fb.SaveChanges();
                    return Ok("Deleted");
                }
            }
            catch (Exception)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
        }
    }
}