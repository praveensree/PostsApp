using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetSocialPost();

        Task<Post> GetSocialPostById(int id);

        Task<Post> CreateSocialPost(Post post);

        Task<Post> UpdateSocialPost(int id, Post post);

        Task<int> UpdateSocialPostLikeHeart(int id, string option);
            
    }
}
