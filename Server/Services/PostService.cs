using PostApp.Models;
using PostApp.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostApp.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public  Task<Post> CreateSocialPost(Post post)
        {
           
            return Task.FromResult(_postRepository.Insert(post));
        }

        public Task<List<Post>> GetSocialPost()
        {

            return Task.FromResult(_postRepository.GetAll());
        }

        public Task<Post> GetSocialPostById(int id)
        {
            return Task.FromResult(_postRepository.GetById(id));
        }

        public Task<Post> UpdateSocialPost(int id, Post post)
        {
            return Task.FromResult(_postRepository.Update(id,post));
        }

        public Task<int> UpdateSocialPostLikeHeart(int id, string option)
        {
            return Task.FromResult(_postRepository.UpdateLikeHeart(id,option));
        }

       
    }
}
