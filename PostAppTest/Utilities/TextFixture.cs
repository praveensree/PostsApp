using Server.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PostAppTest.Utilities
{
    public class TextFixture 
    {
        public Comment CreateCommentforId()
        {
            var res = new Comment()
            {
                CommentDetail = "nice one"

            };
            return  res;
        }
        public Task<Comment> CreatedCommentforId()
        {
            var res = new Comment()
            {
                PostId = 1,
                CommentId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                CommentDetail = "nice one"

            };
            return Task.FromResult(res);
        }
        public Comment GetTestCommentForId()
        {
            var res = new Comment()
            {
                PostId = 1,
                CommentId = 2,
                CreatedDate = null,
                UpdatedDate = null,
                CommentDetail = "nice one"

            };
            return res;
        }
        public Task<Comment> GetTestCommentById()
        {
            var res = new Comment()
            {
                PostId = 1,
                CommentId = 2,
                CreatedDate = null,
                UpdatedDate = null,
                CommentDetail = "nice one"

            };



            return Task.FromResult(res);
        }

        public Task<List<Comment>> GetTestComments()
        {
            List<Comment> comment = new List<Comment>();
            var res = new Comment()
            {
                PostId = 1,
                CommentId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CommentDetail = "nice one"
            };

            comment.Add(res);

            return Task.FromResult(comment);

        }

        public Task<Post> GetTestForUpdate()
        {
            var res = new Post()
            {
                PostId = 1,
                PostName = "Cat",
                PostDescription = "Biggest fish",
          
            };

            return Task.FromResult(res);
        }
        public Task<Post> GetTestPostById()
        {
            var res = new Post()
            {
                PostId = 1,
                PostName = "Whales",
                PostDescription = "Biggest fish",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Likes = 0,
                Hearts = 0
            };

            return Task.FromResult(res);
        }

        public Post GetTestPostForId()
        {
            var res = new Post()
            {
                PostId = 1,
                PostName = "Whales",
                PostDescription = "Biggest fish",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Likes = 0,
                Hearts = 0
            };

            return res;
        }


        public Task<List<Post>> GetTestPost()
        {
            List<Post> post = new List<Post>();
            var res = new Post()
            {
                PostId = 1,
                PostName = "Whales",
                PostDescription = "Biggest fish",
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                Likes = 0,
                Hearts = 0
            };

            post.Add(res);

            return Task.FromResult(post);

        }
    }
}
