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
            var mockService = new Mock<IPostService>();

            mockService.Setup(repo => repo.GetSocialPost())
            .Returns(testFixture.GetTestPostList());

            var controller = new SocialPostController(mockService.Object);

            var result =  await controller.GetSocialPost() as OkObjectResult;

            var actualResponse = result.Value as List<Post>;

            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.True(actualResponse.Count > 0);

        }

        [Fact]
        public async Task GetSocialPostById_Returns_PostAsync()
        {
            var mockService = new Mock<IPostService>();

            mockService.Setup(repo => repo.GetSocialPostById(1))
            .Returns(testFixture.GetTestPost());

            var controller = new SocialPostController(mockService.Object);

            var result = await controller.GetSocialPostById(1) as OkObjectResult;

            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);

            Assert.True(result.Value.GetType() == typeof(Post));
        }

        [Fact]
        public async Task UpdateSocialPost_Returns_PostAsync()
        {     
            var mockService = new Mock<IPostService>();

            mockService.Setup(repo => repo.UpdateSocialPost(It.IsAny<int>(), It.IsAny<Post>()))
            .Returns(testFixture.GetTestPost());

            var controller = new SocialPostController(mockService.Object);

            var result = await controller.UpdateSocialPost(1, testFixture.GetTestPostForId()) as OkObjectResult;

            //var actualResponse = result.Value as Post;

            //Assert.NotNull(actualResponse);
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.True(result.Value.GetType() == typeof(Post));


        }

        [Fact]
        public async Task UpdateSocialPostLike_returns_intAsync()
        {
           
            var mockService = new Mock<IPostService>();
            mockService.Setup(repo => repo.UpdateSocialPostLikeHeart(1, "like"))
            .Returns(Task.FromResult(2));

            var controller = new SocialPostController(mockService.Object);

            var result = await controller.UpdateSocialPostLikeHeart(1, "like") as OkObjectResult;

            Assert.Equal(2, result.Value);
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
        }

        [Fact]
        public async Task CreateSocialPost_Returns_PostAsync()
        {
            // Arrange
            var mockService = new Mock<IPostService>();

            mockService.Setup(repo => repo.CreateSocialPost(It.IsAny<Post>()))
            .Returns(testFixture.GetTestPost());

            var controller = new SocialPostController(mockService.Object);

            var result = await controller.CreateSocialPost(testFixture.GetTestPostForId()) as OkObjectResult;

            //var actualResponse = result.Value as Post;    

            //Assert.NotNull(actualResponse);
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.True(result.Value.GetType() == typeof(Post));


        }
    }
}
