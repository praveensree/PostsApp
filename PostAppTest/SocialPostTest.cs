using Microsoft.AspNetCore.Mvc;
using Moq;
using PostAppTest.Utilities;
using Server.Controllers;
using Server.Models;
using Server.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace SocialPostsTest
{
    [CollectionDefinition("TestData collection")]
    public class SocialPostControllerTest :  IClassFixture<TextFixture>
    {
        TextFixture testFixture;

        public SocialPostControllerTest(TextFixture fixture)
        {
            this.testFixture = fixture;
        }

        [Fact]
        public async Task GetAllSocialPost_Returns_All_postsAsync()
        {
            // Arrange
            var mockRepo = new Mock<IPostService>();

            mockRepo.Setup(repo => repo.GetSocialPost())
            .Returns(testFixture.GetTestPost());

            var controller = new SocialPostController(mockRepo.Object);

            var result =  await controller.GetSocialPost() as OkObjectResult;

            var actualResponse = result.Value as List<Post>;

            Assert.True(actualResponse.Count > 0);
        }

        [Fact]
        public async Task GetSocialPostById_Returns_PostAsync()
        {
            var mockRepo = new Mock<IPostService>();

            mockRepo.Setup(repo => repo.GetSocialPostById(1))
            .Returns(testFixture.GetTestPostById());

            var controller = new SocialPostController(mockRepo.Object);

            var result = await controller.GetSocialPostById(1) as OkObjectResult;

            var actualResponse = result.Value as Post;

            Assert.NotNull(actualResponse);
        }

        [Fact]
        public async Task UpdateSocialPost_Returns_PostAsync()
        {
                
            var mockRepo = new Mock<IPostService>();

            mockRepo.Setup(repo => repo.UpdateSocialPost(1, testFixture.GetTestPostForId()))
            .Returns(testFixture.GetTestPostById());

            var controller = new SocialPostController(mockRepo.Object);

            var result = await controller.UpdateSocialPost(1, testFixture.GetTestPostForId()) as OkObjectResult;

            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public async Task UpdateSocialPostLike_returns_intAsync()
        {
           
            var mockRepo = new Mock<IPostService>();
            mockRepo.Setup(repo => repo.UpdateSocialPostLikeHeart(1, "like"))
            .Returns(Task.FromResult(2));

            var controller = new SocialPostController(mockRepo.Object);

            var result = await controller.UpdateSocialPostLikeHeart(1, "like") as OkObjectResult;

            Assert.Equal(2, result.Value);
        }

        [Fact]
        public async Task CreateSocialPost_Returns_PostAsync()
        {
            // Arrange
            var mockRepo = new Mock<IPostService>();

            mockRepo.Setup(repo => repo.CreateSocialPost(testFixture.GetTestPostForId()))
            .Returns(testFixture.GetTestPostById());

            var controller = new SocialPostController(mockRepo.Object);

            var result = await controller.CreateSocialPost(testFixture.GetTestPostForId()) as OkObjectResult;

            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
        }
    }
}
