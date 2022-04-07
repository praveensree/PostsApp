using Microsoft.AspNetCore.Mvc;
using PostApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Services
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
