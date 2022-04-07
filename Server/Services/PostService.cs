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
            try
            {
                return _postRepository.Insert(post);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<Post>> GetSocialPost()
        {
            try
            {
                return _postRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Post> GetSocialPostById(int id)
        {
            try
            {
                return _postRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<Post> UpdateSocialPost(int id, Post post)
        {
            try
            {
                return _postRepository.Update(id, post);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> UpdateSocialPostLikeHeart(int id, string option)
        {
            try
            {
                return _postRepository.UpdateLikeHeart(id, option);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
    }
}
