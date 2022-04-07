using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Repository
{
   public interface IPostRepository
    {
        Task<List<Post>> GetAll();
        Task<Post> GetById(int id);

         Task<Post> Insert(Post post);

        Task<Post> Update(int id, Post post);

        Task<int> UpdateLikeHeart(int id, string option);
    }
}
