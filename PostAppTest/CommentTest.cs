using Moq;
using Server.Controllers;
using Server.Models;
using Server.Repository;
using System;
using System.Collections.Generic;
using Xunit;

namespace PostAppTest
{
    public class CommentTest
    {
        [Fact]
        public void GetCommentsByPostId_Returns_All_Comments()
        {

            var id = 1;
            // Arrange
            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(repo => repo.GetCommentsByPostId( id))
            .Returns(GetTestComments());

            var controller = new CommentsController(mockRepo.Object);

            var result = controller.GetCommentsByPostId(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetCommentsByCommentId_Returns_Comment()
        {

            var id = 1;
            // Arrange
            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(repo => repo.GetCommentByCommentId(id))
            .Returns(GetTestCommentById());

            var controller = new CommentsController(mockRepo.Object);

            var result = controller.GetCommentByCommentId(2);

            Assert.NotNull(result);
        }

        [Fact]

        public void CreateComment_Returns_Comment()
        {


            // Arrange
            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(repo => repo.CreateComment(GetTestCommentById()))
            .Returns(GetTestCommentById());

            var controller = new CommentsController(mockRepo.Object);

            var result = controller.CreateComment(GetTestCommentById());

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateSocialPost_Returns_Post()
        {
            var id = 1;


            var mockRepo = new Mock<ICommentRepository>();

            mockRepo.Setup(repo => repo.UpdateCommentById(id, GetTestCommentById()))
            .Returns(GetTestCommentById());

            var controller = new CommentsController(mockRepo.Object);

            var result = controller.UpdateCommentById(id, GetTestCommentById());

            Assert.NotNull(result);
        }
        public Comment GetTestCommentById()
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

        public List<Comment> GetTestComments()
        {
            List<Comment> comment = new List<Comment>();
            var res = new Comment()
            {
                PostId = 1,
                CommentId =2,
                CreatedDate = null,
                UpdatedDate = null,
                CommentDetail="nice one"
            };

            comment.Add(res);

            return comment;

        }
    }
}
