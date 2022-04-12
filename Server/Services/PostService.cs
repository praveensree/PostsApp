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
            try
            {
                return await _postRepository.Insert(post);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Post>> GetSocialPost()
        {
            try
            {
                return await _postRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Post> GetSocialPostById(int id)
        {
            try
            {
                return await _postRepository.GetById(id);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<Post> UpdateSocialPost(int id, Post post)
        {
            try
            {
                return await _postRepository.Update(id, post);
            }
            catch (Exception ex) { throw ex; }
        }

        public async Task<int> UpdateSocialPostLikeHeart(int id, string option)
        {
            try
            {
                return await _postRepository.UpdateLikeHeart(id, option);
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
