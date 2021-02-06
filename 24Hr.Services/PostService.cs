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
    public class PostService
    {
        private readonly Guid _userId;

        public PostService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity = new Post()
            {
                Author = _userId,
                PostTitle = model.PostTitle,
                PostText = model.PostText,
                PostCreatedUtc = DateTimeOffset.Now

            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Posts
                    .Where(e => e.Author == _userId)
                    .Select(e => new PostListItem
                    {
                        PostId = e.PostId,
                        PostTitle = e.PostTitle,
                        //CommentId = e.CommentId,
                        CreatedUtc = e.PostCreatedUtc

                    });
                return query.ToArray();
            }
        }
        
        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Posts
                    .Single(e => e.PostId == id && e.Author == _userId);

                return
                    new PostDetail
                    {
                        PostId = entity.PostId,
                        PostTitle = entity.PostTitle,
                        PostText = entity.PostText,
                        CreatedUtc = entity.PostCreatedUtc,
                    };
            }
        }

        public bool UpdatePost(PostEdit model)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == model.PostId && e.Author == _userId);

                entity.PostTitle = model.PostTitle;
                entity.PostText = model.PostText;
                entity.ModifiedUtc = model.ModifiedUtc;
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePost(int postId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Posts.Single(e => e.PostId == postId && e.Author == _userId);

                ctx.Posts.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }

}
