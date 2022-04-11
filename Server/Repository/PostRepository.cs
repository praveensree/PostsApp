using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly fbContext context;
        public PostRepository(fbContext context)
        {
            this.context = context;
        }

        public async Task<Post> Insert(Post post)
        {
            post.CreatedDate = DateTime.Now;
            post.UpdatedDate = null;
            post.Likes = 0;
            post.Hearts = 0;
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }

        public async Task<List<Post>> GetAll()
        {
            return await context.Posts.ToListAsync();
        }

        public async Task<Post> GetById(int id)
        {
            try
            {
                return await context.Posts.FirstAsync(x => x.PostId == id);
            }
            catch (Exception)
            {
                throw new Exception("Invalid Id");
            }
        }

        public async Task<Post> Update(int id, Post post)
        {
            try
            {
                var update = await context.Posts.FirstAsync(x => x.PostId == id);
                update.PostName = post.PostName;
                update.PostDescription = post.PostDescription;
                update.UpdatedDate = DateTime.Now;
                await context.SaveChangesAsync();
                return await context.Posts.FirstAsync(x => x.PostId == id);
            }
            catch (Exception )
            {
                throw new Exception("Please Enter a valid Id");
            }
        }

        public async Task<int> UpdateLikeHeart(int id, string option)
        {
            try
            {
                var update = await context.Posts.FirstAsync(x => x.PostId == id);
                if (option == "like" || option == "heart")
                {
                    if (option == "like")
                    {
                        update.Likes++;
                        await context.SaveChangesAsync();
                        return (int)update.Likes;
                    }
                    else
                    {
                        update.Hearts++;
                        await context.SaveChangesAsync();
                        return (int)update.Hearts;
                    }
                }
                else if (option == "unlike" || option == "disheart")
                {
                    if (option == "unlike")
                    {
                        if (update.Likes > 0)
                        {
                            update.Likes--;
                            await context.SaveChangesAsync();
                            return (int)update.Likes;
                        }
                        else
                        {
                            update.Likes = 0;
                            await context.SaveChangesAsync();
                            return (int)update.Likes;
                        }
                    }
                    else
                    {
                        if (update.Hearts > 0)
                        {
                            update.Hearts--;
                            await context.SaveChangesAsync();
                            return (int)update.Hearts;
                        }
                        else
                        {
                            update.Hearts = 0;
                            await context.SaveChangesAsync();
                            return (int)update.Hearts;
                        }
                    }
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
