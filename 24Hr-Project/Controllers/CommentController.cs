using _24Hr.Models;
using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace _24Hr_Project.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            CommentServices commentService = CreateCommentService();
            var comment = commentService.GetComments(id);
            return Ok(comment);
        }
        public IHttpActionResult GetById(int id)
        {
            CommentServices commentService = CreateCommentService();
            var comment = commentService.GetCommentById(id);
            return Ok(comment);
        }
        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            CommentServices commentService = CreateCommentService();

            if (!commentService.CreateComment(comment)) return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Put(CommentEdit comment)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            CommentServices service = CreateCommentService();

            if (!service.UpdateComment(comment)) return InternalServerError();
            return Ok();
        }
        public IHttpActionResult Delete(int id)
        {
            CommentServices services = CreateCommentService();

            if (!services.DeleteComment(id)) return InternalServerError();
            return Ok();
        }
        private CommentServices CreateCommentService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentServices(userId);
            return commentService;
        }
    }
}