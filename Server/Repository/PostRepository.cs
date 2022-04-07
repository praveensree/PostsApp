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
        public Post Insert(Post post)
        {
                    post.CreatedDate = DateTime.Now;
                    post.UpdatedDate = null;
                    post.Likes = 0;
                    post.Hearts = 0;
                    context.Posts.Add(post);
                    context.SaveChangesAsync();
                    return post;
        }

        public List<Post> GetAll()
        {
            
                return context.Posts.ToList();
           
        }

        public Post GetById(int id)
        {
                try
                {
                    return context.Posts.First(x => x.PostId == id);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
           
        }

        public Post Update(int id, Post post)
        {
            
                try
                {
                    var update = context.Posts.First(x => x.PostId == id);
                    update.PostName = post.PostName;
                    update.PostDescription = post.PostDescription;
                    update.UpdatedDate = DateTime.Now;
                    context.SaveChanges();
                    return context.Posts.First(x => x.PostId == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            
        }

        public int UpdateLikeHeart(int id, string option)
        {
           
                try
                {

                    var update = context.Posts.First(x => x.PostId == id);
                    if (option == "like" || option == "heart")
                    {
                        if (option == "like")
                        {
                            update.Likes++;
                            context.SaveChanges();
                            return (int)update.Likes;
                        }
                        else
                        {
                            update.Hearts++;
                            context.SaveChanges();
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
                                context.SaveChanges();
                                return (int)update.Likes;
                            }
                            else
                            {
                                update.Likes = 0;
                                context.SaveChanges();
                                return (int)update.Likes;
                            }
                        }
                        else
                        {
                            if (update.Hearts > 0)
                            {
                                update.Hearts--;
                                context.SaveChanges();
                                return (int)update.Hearts;
                            }
                            else
                            {
                                update.Hearts = 0;
                                context.SaveChanges();
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
