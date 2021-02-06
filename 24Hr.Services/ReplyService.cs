using _24Hr.Data;
using _24Hr.Models;
using _24Hr_Project.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _24Hr.Services
{
    public class ReplyService
    {
        private readonly Guid _userId;

        public ReplyService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReply(ReplyCreate model)
        {
            var entity =
                new Reply()
                {
                    OwnerId = _userId,
                    ReplyId = model.ReplyId,
                    ReplyText = model.ReplyText,
                    ReplyCreatedUtc = DateTimeOffset.Now,
                    CommentId = model.CommentId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Replies.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReplyListItem> GetReplies(int CommentId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Replies
                        .Where(e => e.CommentId == CommentId)
                        .Select(
                            e =>
                                new ReplyListItem
                                {
                                    ReplyId = e.ReplyId,
                                    ReplyText = e.ReplyText,
                                    ReplyCreatedUtc = e.ReplyCreatedUtc
                                }
                        );

                return query.ToArray();
            }
        }
    }
}

