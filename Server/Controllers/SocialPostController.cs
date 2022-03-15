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

        [HttpPut("Like/{id}/{option}")]
        public IActionResult UpdateSocialPostLike(int id, string option)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    if (option == "like")
                    {

                        var update = fb.Posts.First(x => x.PostId == id);
                        update.Likes++;
                        fb.SaveChanges();
                        return Ok(update.Likes);
                    }
                    else if (option == "unlike")
                    {
                        var update = fb.Posts.First(x => x.PostId == id);
                        if (update.Likes > 0)
                        {
                            update.Likes--;
                            fb.SaveChanges();
                            return Ok(update.Likes);
                        }
                        else
                        {
                            update.Likes=0;
                            fb.SaveChanges();
                            return Ok(update.Likes);
                        }
                    }
                    else
                    {
                        return NotFound();

                    }
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPut("Heart/{id}/{option}")]
        public IActionResult UpdateSocialPostHeart(int id, string option)
        {
            try
            {
                using (fbContext fb = new fbContext())
                {
                    if (option == "heart")
                    {
                        var update= fb.Posts.First(x => x.PostId == id);
                        update.Hearts++;
                        fb.SaveChanges();
                        return Ok(update.Hearts);
                    }
                    else if (option == "disheart")
                    {
                        var update = fb.Posts.First(x => x.PostId == id);
                        if (update.Hearts > 0)
                        {
                            update.Hearts--;
                            fb.SaveChanges();
                            return Ok(update.Hearts);
                        }
                        else
                        {
                            update.Hearts = 0;
                            fb.SaveChanges();
                            return Ok(update.Hearts);
                        } 
                    }
                    else
                        return NotFound();

                }

            }
            catch (Exception)
            {
                return NotFound();

            }
        }

    }
}