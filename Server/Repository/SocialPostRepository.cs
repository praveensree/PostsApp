using Microsoft.EntityFrameworkCore;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
    public class SocialPostRepository : ISocialPostRepository
    {
        private readonly PostAppContext context;
        public SocialPostRepository(PostAppContext context)
        {
            this.context = context;
        }

        public async Task<Post> Insert(Post post)
        {

            if (string.IsNullOrWhiteSpace(post.PostDescription))
            {
                throw new ArgumentException(nameof(post.PostDescription));
            }
            else if (string.IsNullOrWhiteSpace(post.PostName))
            {
                throw new ArgumentException(nameof(post.PostName));
            }
            else
            {
                post.CreatedDate = DateTime.Now;
                post.UpdatedDate = null;
                post.Likes = 0;
                post.Hearts = 0;
                context.Posts.Add(post);
                await context.SaveChangesAsync();
                return post;
            }
        }

        public async Task<List<Post>> GetAll()
        {
            var PostList = await context.Posts.ToListAsync();
            if (PostList != null)
            {
                return PostList;
            }
            else
            {
                throw new Exception("No Records");
            }
        }

        public async Task<Post> GetById(int id)
        {
            var Post = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (Post != null)
            {
                return Post;
            }
            else
            {
                throw new ArgumentException(nameof(id));
            }
        }

        public async Task<Post> Update(int id, Post post)
        {

            var Update = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (Update != null)
            {

                if (string.IsNullOrWhiteSpace(post.PostDescription))
                {
                    throw new ArgumentException(nameof(post.PostDescription));
                }
                else if (string.IsNullOrWhiteSpace(post.PostName))
                {
                    throw new ArgumentException(nameof(post.PostName));
                }
                else
                {
                    Update.PostName = post.PostName;
                    Update.PostDescription = post.PostDescription;
                    Update.UpdatedDate = DateTime.Now;
                    await context.SaveChangesAsync();
                    return await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                }
            }
            else
            {
                throw new ArgumentException(nameof(id));
            }
        }

        public async Task<int> UpdateLikeHeart(int id, string option)
        {

            var UpdateLikeorHeart = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (UpdateLikeorHeart != null)
            {
                if (option == "like" || option == "heart")
                {
                    if (option == "like")
                    {
                        UpdateLikeorHeart.Likes++;
                        await context.SaveChangesAsync();
                        return (int)UpdateLikeorHeart.Likes;
                    }
                    else
                    {
                        UpdateLikeorHeart.Hearts++;
                        await context.SaveChangesAsync();
                        return (int)UpdateLikeorHeart.Hearts;
                    }
                }
                else if (option == "unlike" || option == "disheart")
                {
                    if (option == "unlike")
                    {
                        if (UpdateLikeorHeart.Likes > 0)
                        {
                            UpdateLikeorHeart.Likes--;
                            await context.SaveChangesAsync();
                            return (int)UpdateLikeorHeart.Likes;
                        }
                        else
                        {
                            UpdateLikeorHeart.Likes = 0;
                            await context.SaveChangesAsync();
                            return (int)UpdateLikeorHeart.Likes;
                        }
                    }
                    else
                    {
                        if (UpdateLikeorHeart.Hearts > 0)
                        {
                            UpdateLikeorHeart.Hearts--;
                            await context.SaveChangesAsync();
                            return (int)UpdateLikeorHeart.Hearts;
                        }
                        else
                        {
                            UpdateLikeorHeart.Hearts = 0;
                            await context.SaveChangesAsync();
                            return (int)UpdateLikeorHeart.Hearts;
                        }
                    }
                }
                else
                {
                    throw new ArgumentException(nameof(option));
                }
            }
            else
            {
                throw new ArgumentException(nameof(id));
            }
        }

    }
}

