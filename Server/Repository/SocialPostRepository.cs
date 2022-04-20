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

            if (string.IsNullOrWhiteSpace(post.PostDescription) || string.IsNullOrWhiteSpace(post.PostName))
            {
                return post;
            }
            else
            {
                post.CreatedDate = DateTime.Now;
                post.UpdatedDate = null;
                post.Likes = 0;
                post.Hearts = 0;
                context.Posts.Add(post);
                var Po = await context.SaveChangesAsync()>0;
                if (Po)
                {
                    return post;
                }
                post.PostId = -1;
                return post;
            }
        }

        public async Task<List<Post>> GetAll()
        {
            var PostList = await context.Posts.ToListAsync();
                return PostList;
        }

        public async Task<Post> GetById(int id)
        {
            var Post = await context.Posts.SingleOrDefaultAsync(x => x.PostId == id);
            return Post;  
        }

        public async Task<Post> Update(int id, Post post)
        {

            var postData = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (postData != null)
            {
                if (string.IsNullOrWhiteSpace(post.PostDescription) || (string.IsNullOrWhiteSpace(post.PostName)))
                {
                    return post;
                }
                else
                {
                    postData.PostName = post.PostName;
                    postData.PostDescription = post.PostDescription;
                    postData.UpdatedDate = DateTime.Now;
                    var Po = await context.SaveChangesAsync() > 0;
                    if (Po)
                    {
                        return await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
                    }
                    post.PostId = -2;
                    return post;
                }
            }
            else
            {
                post.PostId = -1;
                return post;
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
                        var Po = await context.SaveChangesAsync() > 0;
                        if (Po)
                        {
                            return (int)UpdateLikeorHeart.Likes;
                        }
                        return -3;
                    }
                    else
                    {
                        UpdateLikeorHeart.Hearts++;
                        var Po = await context.SaveChangesAsync() > 0;
                        if (Po)
                        {
                            return (int)UpdateLikeorHeart.Hearts;
                        }
                        return -3;
                    }
                }
                else if (option == "unlike" || option == "disheart")
                {
                    if (option == "unlike")
                    {
                        if (UpdateLikeorHeart.Likes > 0)
                        {
                            UpdateLikeorHeart.Likes--;
                            var Po = await context.SaveChangesAsync() > 0;
                            if (Po)
                            {
                                return (int)UpdateLikeorHeart.Likes;
                            }
                            return -3;
                        }
                        else
                        {
                            UpdateLikeorHeart.Likes = 0;
                            var Po = await context.SaveChangesAsync() > 0;
                            if (Po)
                            {
                                return (int)UpdateLikeorHeart.Likes;
                            }
                            return -3;
                        }
                    }
                    else
                    {
                        if (UpdateLikeorHeart.Hearts > 0)
                        {
                            UpdateLikeorHeart.Hearts--;
                            var Po = await context.SaveChangesAsync() > 0;
                            if (Po)
                            {
                                return (int)UpdateLikeorHeart.Hearts;
                            }
                            return -3;
                        }
                        else
                        {
                            UpdateLikeorHeart.Hearts = 0;
                            var Po = await context.SaveChangesAsync() > 0;
                            if (Po)
                            {
                                return (int)UpdateLikeorHeart.Hearts;
                            }
                            return -3;
                        }
                    }
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -2;
            }
        }

    }
}

