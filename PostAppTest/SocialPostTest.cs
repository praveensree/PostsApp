using Moq;
using Server.Controllers;
using Server.Models;
using Server.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace SocialPostsTest
{
    public class SocialPostControllerTest
    {

        [Fact]
        public void GetAllSocialPost_Returns_All_posts()
        {
            // Arrange
            var mockRepo = new Mock<IPostRepository>();

            mockRepo.Setup(repo => repo.GetSocialPost())
            .Returns(GetTestPost());

            var controller = new SocialPostController(mockRepo.Object);

            var result = controller.GetSocialPost();

            Assert.NotNull(result);
        }

        [Fact]
        public void GetSocialPostById_Returns_Post()
        {
            var id = 1;

           
            var mockRepo = new Mock<IPostRepository>();

            mockRepo.Setup(repo => repo.GetSocialPostById(id))
            .Returns(GetTestPostById());

            var controller = new SocialPostController(mockRepo.Object);

            var result = controller.GetSocialPostById(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateSocialPost_Returns_Post()
        {
            var id = 1;

           
            var mockRepo = new Mock<IPostRepository>();

            mockRepo.Setup(repo => repo.UpdateSocialPost(id, GetTestPostById()))
            .Returns(GetTestPostById());

            var controller = new SocialPostController(mockRepo.Object);

            var result = controller.UpdateSocialPost(id, GetTestPostById());

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateSocialPostLike_returns_int()
        {
            var id = 1;
            var option = "like";
            var mockRepo = new Mock<IPostRepository>();
            mockRepo.Setup(repo => repo.UpdateSocialPostLike(id, option))
            .Returns(LikesorHearts(id));
            var controller = new SocialPostController(mockRepo.Object);

            var result = controller.UpdateSocialPostLike(id, option);

            Assert.NotNull(result);
        }

        [Fact]
        public void CreateSocialPost_Returns_Post()
        {


            // Arrange
            var mockRepo = new Mock<IPostRepository>();

            mockRepo.Setup(repo => repo.CreateSocialPost(GetTestPostById()))
            .Returns(GetTestPostById());

            var controller = new SocialPostController(mockRepo.Object);

            var result = controller.CreateSocialPost(GetTestPostById());

            Assert.NotNull(result);
        }

      

        public int LikesorHearts(int id)
        {
            var res = id;
            return res++;
        }
      
        public Post GetTestPostById()
        {
            
            var res = new Post()
            {
                PostId = 1,
                PostName = "Whales",
                PostDescription = "Biggest fish",
                CreatedDate = null,
                UpdatedDate = null,
                Likes = 0,
                Hearts = 0
            };

            

            return res;

        }


        public List<Post> GetTestPost()
        {
            List<Post> post = new List<Post>();
            var res = new Post()
            {
                PostId = 1,
                PostName = "Whales",
                PostDescription = "Biggest fish",
                CreatedDate = null,
                UpdatedDate = null,
                Likes = 0,
                Hearts = 0
            };

            post.Add(res);

            return post;

        }
    }
}
