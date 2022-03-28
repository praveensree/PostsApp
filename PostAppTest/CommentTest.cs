﻿using Microsoft.AspNetCore.Mvc;
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

namespace PostAppTest
{
    [CollectionDefinition("TestData collection")]
    public class CommentTest :  IClassFixture<TextFixture>
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
            var mockRepo = new Mock<ICommentService>();

            mockRepo.Setup(repo => repo.GetCommentsByPostId(1))
            .Returns(testFixture.GetTestComments());

            var controller = new CommentsController(mockRepo.Object);

            var result = await controller.GetCommentsByPostId(1) as OkObjectResult;

            var actualResponse = result.Value as List<Comment>;

            Assert.Single(actualResponse);
        }

        [Fact]
        public async System.Threading.Tasks.Task GetCommentsByCommentId_Returns_CommentAsync()
        {
            // Arrange
            var mockRepo = new Mock<ICommentService>();

            mockRepo.Setup(repo => repo.GetCommentByCommentId(1))
            .Returns(testFixture.GetTestCommentById());

            var controller = new CommentsController(mockRepo.Object);

            var result = await controller.GetCommentByCommentId(1) as OkObjectResult;

            var actualResponse = result.Value as Comment;

            Assert.NotNull(actualResponse);
        }

        [Fact]

        public async Task CreateComment_Returns_CommentAsync()
        {
            // Arrange
            var mockRepo = new Mock<ICommentService>();

            mockRepo.Setup(repo => repo.CreateComment(testFixture.CreateCommentforId()))
            .Returns(testFixture.CreatedCommentforId());

            var controller = new CommentsController(mockRepo.Object);

            var result = await controller.CreateComment(testFixture.CreateCommentforId()) as OkObjectResult;

            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
        
        }

        [Fact]
        public async System.Threading.Tasks.Task UpdateSocialPost_Returns_PostAsync()
        {
           
            var mockRepo = new Mock<ICommentService>();

            mockRepo.Setup(repo => repo.UpdateCommentById(2, testFixture.GetTestCommentForId()))
            .Returns(testFixture.GetTestCommentById());

            var controller = new CommentsController(mockRepo.Object);

            var result = await controller.UpdateCommentById(2, testFixture.GetTestCommentForId()) as OkObjectResult;

            
            Assert.Equal(Convert.ToInt16(HttpStatusCode.OK), result.StatusCode);
     
        }

    }
}