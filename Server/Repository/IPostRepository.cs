using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
   public interface IPostRepository
    {
        List<Post> GetSocialPost();
        Post GetSocialPostById(int id);

        Post CreateSocialPost(Post post);

        Post UpdateSocialPost(int id, Post post);

        int UpdateSocialPostLike(int id, string option);
    }
}
