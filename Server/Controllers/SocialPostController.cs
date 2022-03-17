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
        public async Task<IActionResult> GetSocialPost()
        {
            //TODO: Have to write logic here
            try
            {
                using (fbContext fb = new fbContext())
                {

                    var response = await Task.FromResult(fb.Posts.ToList());
                    return Ok(response);
                }
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
                using (fbContext fb = new fbContext())
                {
                    var response = await Task.FromResult(fb.Posts.First(x => x.PostId == id));
                    return Ok(response);
                }
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
                using (fbContext fb = new fbContext())
                {
                    post.CreatedDate = DateTime.Now;
                    post.UpdatedDate = null;
                    post.Likes = 0;
                    post.Hearts = 0;
                    fb.Posts.Add(post);
                    fb.SaveChanges();
                    return Ok(await Task.FromResult(post));
                }
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
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    update.PostName = post.PostName;
                    update.PostDescription = post.PostDescription;
                    update.UpdatedDate = DateTime.Now;
                    fb.SaveChanges();
                    return Ok(await Task.FromResult(fb.Posts.First(x => x.PostId == id)));
                }
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
                using (fbContext fb = new fbContext())
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    if (option == "like"|| option == "heart")
                    {
                        if (option == "like")
                        {
                            update.Likes++;
                            fb.SaveChanges();
                            return Ok(await Task.FromResult(update.Likes));
                        }
                        else
                        {
                            update.Hearts++;
                            fb.SaveChanges();
                            return Ok(await Task.FromResult(update.Hearts));
                        }
                    }
                    else if (option == "unlike"|| option == "disheart")
                    {
                        if (option == "unlike")
                        {
                            if (update.Likes > 0)
                            {
                                update.Likes--;
                                fb.SaveChanges();
                                return Ok(await Task.FromResult(update.Likes));
                            }
                            else
                            {
                                update.Likes = 0;
                                fb.SaveChanges();
                                return Ok(await Task.FromResult(update.Likes));
                            }
                        }
                        else
                        {
                            if (update.Hearts > 0)
                            {
                                update.Hearts--;
                                fb.SaveChanges();
                                return Ok(await Task.FromResult(update.Hearts));
                            }
                            else
                            {
                                update.Hearts = 0;
                                fb.SaveChanges();
                                return Ok(await Task.FromResult(update.Hearts));
                            }
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

    }
}