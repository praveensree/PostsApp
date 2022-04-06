using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
    public class PostRepository : IPostRepository
    {
        public Post Insert(Post post)
        {
            using (fbContext fb = new fbContext())
            {
                try
                {
                    post.CreatedDate = DateTime.Now;
                    post.UpdatedDate = null;
                    post.Likes = 0;
                    post.Hearts = 0;
                    fb.Posts.Add(post);
                    fb.SaveChanges();
                    return post;
                }

                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public List<Post> GetAll()
        {
            using (fbContext fb = new fbContext())
            {
                return fb.Posts.ToList();
            }
        }

        public Post GetById(int id)
        {
            using (fbContext fb = new fbContext())
            {
                try
                {


                    return fb.Posts.First(x => x.PostId == id);

                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public Post Update(int id, Post post)
        {
            using (fbContext fb = new fbContext())
            {
                try
                {
                    var update = fb.Posts.First(x => x.PostId == id);
                    update.PostName = post.PostName;
                    update.PostDescription = post.PostDescription;
                    update.UpdatedDate = DateTime.Now;
                    fb.SaveChanges();
                    return fb.Posts.First(x => x.PostId == id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public int UpdateLikeHeart(int id, string option)
        {
            using (fbContext fb = new fbContext())
            {
                try
                {

                    var update = fb.Posts.First(x => x.PostId == id);
                    if (option == "like" || option == "heart")
                    {
                        if (option == "like")
                        {
                            update.Likes++;
                            fb.SaveChanges();
                            return (int)update.Likes;
                        }
                        else
                        {
                            update.Hearts++;
                            fb.SaveChanges();
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
                                fb.SaveChanges();
                                return (int)update.Likes;
                            }
                            else
                            {
                                update.Likes = 0;
                                fb.SaveChanges();
                                return (int)update.Likes;
                            }
                        }
                        else
                        {
                            if (update.Hearts > 0)
                            {
                                update.Hearts--;
                                fb.SaveChanges();
                                return (int)update.Hearts;
                            }
                            else
                            {
                                update.Hearts = 0;
                                fb.SaveChanges();
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
}
