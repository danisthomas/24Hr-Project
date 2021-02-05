﻿using _24Hr.Data;
using _24Hr.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr.Services
{
    public class CommentServices
    {

        public readonly Guid _userId;
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
        

    }
}
