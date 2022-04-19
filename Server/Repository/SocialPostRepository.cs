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
                throw new ArgumentException(nameof(post.PostDescription), "Please enter the Description");
            }
            else if (string.IsNullOrWhiteSpace(post.PostName))
            {
                throw new ArgumentException(nameof(post.PostName),"Please enter the PostName");
            }
            else
            {
                post.CreatedDate = DateTime.Now;
                post.UpdatedDate = null;
                post.Likes = 0;
                post.Hearts = 0;
                context.Posts.Add(post);
                var Po = await context.SaveChangesAsync()>0;
                return Po ? post : throw new Exception("Unable to process the request");
            }
        }

        public async Task<List<Post>> GetAll()
        {
            var PostList = await context.Posts.ToListAsync();
            if (PostList.Count>0)
            {
                return PostList;
            }
            else
            {
                throw new Exception("No Records Found");
            }
        }

        public async Task<Post> GetById(int id)
        {
            var Post = await context.Posts.SingleOrDefaultAsync(x => x.PostId == id);
            if (Post != null)
            {
                return Post;
            }
            else
            {
                throw new ArgumentException(nameof(id), "Invalid Id");
            }
        }

        public async Task<Post> Update(int id, Post post)
        {

            var Update = await context.Posts.FirstOrDefaultAsync(x => x.PostId == id);
            if (Update != null)
            {
                if (string.IsNullOrWhiteSpace(post.PostDescription))
                {
                    throw new ArgumentException(nameof(post.PostDescription),"post Description Must");
                }
                else if (string.IsNullOrWhiteSpace(post.PostName))
                {
                    throw new ArgumentException(nameof(post.PostName),"Post Name Must");
                }
                else
                {
                    Update.PostName = post.PostName;
                    Update.PostDescription = post.PostDescription;
                    Update.UpdatedDate = DateTime.Now;
                    var Po = await context.SaveChangesAsync() > 0;
                    return Po? await context.Posts.FirstOrDefaultAsync(x => x.PostId == id): throw new Exception("unable to process");
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
                        var Po = await context.SaveChangesAsync() > 0;
                        return Po? (int)UpdateLikeorHeart.Likes : throw new Exception("unable to process");
                    }
                    else
                    {
                        UpdateLikeorHeart.Hearts++;
                        var Po = await context.SaveChangesAsync() > 0;
                        return Po? (int)UpdateLikeorHeart.Hearts : throw new Exception("unable to process");
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
                            return Po ? (int)UpdateLikeorHeart.Likes : throw new Exception("unable to process");
                        }
                        else
                        {
                            UpdateLikeorHeart.Likes = 0;
                            var Po = await context.SaveChangesAsync() > 0;
                            return Po ? (int)UpdateLikeorHeart.Likes : throw new Exception("unable to process");
                        }
                    }
                    else
                    {
                        if (UpdateLikeorHeart.Hearts > 0)
                        {
                            UpdateLikeorHeart.Hearts--;
                            var Po = await context.SaveChangesAsync() > 0;
                            return Po ? (int)UpdateLikeorHeart.Hearts : throw new Exception("unable to process");
                        }
                        else
                        {
                            UpdateLikeorHeart.Hearts = 0;
                            var Po = await context.SaveChangesAsync() > 0;
                            return Po ? (int)UpdateLikeorHeart.Hearts : throw new Exception("unable to process");
                        }
                    }
                }
                else
                {
                    throw new ArgumentException(nameof(option),"option is invalid please use like or heart");
                }
            }
            else
            {
                throw new ArgumentException(nameof(id),"Invalid Id");
            }
        }

    }
}

