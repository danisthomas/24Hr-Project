using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _24Hr_Project.Data;
using _24Hr.Models;
using _24Hr.Data;

namespace _24Hr.Services
{
    public class CommentServices
    {
        private readonly Guid _userId;
        public CommentServices(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment
                {
                    CommentAuthor = _userId,
                    CommentText = model.CommentText,
                    CommentCreatedUtc = DateTimeOffset.Now
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public CommentDetail GetCommentById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == id && e.CommentAuthor == _userId);
                return
                    new CommentDetail
                    {
                        CommentId = entity.CommentId,
                        CommentCreatedUtc = entity.CommentCreatedUtc,
                        CommentModifiedUTC = entity.CommentModifiedUtc
                    };
            }
        }
        public bool UpdateComment(CommentEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == model.CommentId && e.CommentAuthor == _userId);
                entity.CommentText = model.CommentText;
                entity.CommentModifiedUtc = DateTimeOffset.UtcNow;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteComment(int noteId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Comments
                        .Single(e => e.CommentId == noteId && e.CommentAuthor == _userId);
                ctx.Comments.Remove(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<CommentNewList> GetComments(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                  ctx
                      .Comments
                      .Where(e => e.PostId == id)
                      .Select(
                        e => new CommentNewList
                        {
                            CommentId = e.CommentId,
                            CommentText = e.CommentText,
                            CommentCreatedUTC = e.CommentCreatedUtc
                        });
                return query.ToArray();
            }
        }
    }
}
