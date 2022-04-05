using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Repository
{
   public interface IPostRepository
    {
        List<Post> GetAll();
        Post GetById(int id);

        Post Insert(Post post);

        Post Update(int id, Post post);

        int UpdateLikeHeart(int id, string option);
    }
}
