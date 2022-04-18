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
        private readonly ISocialPostRepository _postRepository;
        public PostService(ISocialPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<Post> CreateSocialPost(Post post)
        {
            return await _postRepository.Insert(post);
        }

        public async Task<List<Post>> GetSocialPost()
        {
            return await _postRepository.GetAll();
        }

        public async Task<Post> GetSocialPostById(int id)
        {
            return await _postRepository.GetById(id);
        }

        public async Task<Post> UpdateSocialPost(int id, Post post)
        {
            return await _postRepository.Update(id, post);
        }

        public async Task<int> UpdateSocialPostLikeHeart(int id, string option)
        {
            return await _postRepository.UpdateLikeHeart(id, option);
        }
    }
}
