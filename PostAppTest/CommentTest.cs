using Microsoft.AspNetCore.Mvc;
using Moq;
using PostAppTest.Utilities;
using Server.Controllers;
using PostApp.Models;
using PostApp.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace PostAppTest
{
    [CollectionDefinition("TestData collection")]
    public class CommentTest : IClassFixture<TextFixture>
    {
        TextFixture testFixture;
        public CommentTest(TextFixture fixture)
        {
            this.testFixture = fixture;
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCommentsByPostId_Returns_All_CommentsAsync()
        {
            // Arrange
            var mockService = new Mock<ICommentService>();
            mockService.Setup(repo => repo.GetCommentsByPostId(1))
            .Returns(testFixture.GetTestComments());
            var controller = new CommentsController(mockService.Object);
            var result = await controller.GetCommentsByPostId(1) as OkObjectResult;
            var actualResponse = result.Value as List<Comment>;
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.Single(actualResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCommentsByCommentId_Returns_CommentAsync()
        {
            // Arrange
            var mockService = new Mock<ICommentService>();
            mockService.Setup(repo => repo.GetCommentByCommentId(1))
            .Returns(testFixture.GetTestCommentById());
            var controller = new CommentsController(mockService.Object);
            var result = await controller.GetCommentByCommentId(1) as OkObjectResult;
            var actualResponse = result.Value as List<Comment>;
            Assert.True(actualResponse.Count > 0);
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.True(result.Value.GetType() == typeof(Comment));
        }

        [Fact]
        public async Task CreateComment_Returns_CommentAsync()
        {
            // Arrange
            var mockService = new Mock<ICommentService>();
            mockService.Setup(repo => repo.CreateComment(It.IsAny<Comment>()))
            .Returns(testFixture.CreatedCommentforId());
            var controller = new CommentsController(mockService.Object);
            var result = await controller.CreateComment(testFixture.CreateCommentforId()) as OkObjectResult;
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.NotNull(result);
            Assert.True(result.Value.GetType() == typeof(Comment));
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateSocialPost_Returns_PostAsync()
        {
            var mockService = new Mock<ICommentService>();

            mockService.Setup(repo => repo.UpdateCommentById(It.IsAny<int>(), It.IsAny<Comment>()))
            .Returns(testFixture.GetTestCommentById());
            var controller = new CommentsController(mockService.Object);
            var result = await controller.UpdateCommentById(2, testFixture.GetTestCommentForId()) as OkObjectResult;
            var actualResponse = result.Value as Comment;
            Assert.NotNull(actualResponse);
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
            Assert.True(result.Value.GetType() == typeof(Comment));
            Assert.Equal("nice one", actualResponse.CommentDetail);
        }
    }
}
