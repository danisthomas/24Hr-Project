﻿using _24Hr.Models;
using _24Hr.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;

namespace _24Hr_Project.Controllers
{   
    [System.Web.Mvc.Authorize]
    public class Reply2Controller : ApiController
    
 
        {
            private ReplyService CreateReplyService()
            {
                var userId = Guid.Parse(User.Identity.GetUserId());
                var replyService = new ReplyService(userId);
                return replyService;
            }

            public IHttpActionResult Get()
            {
                ReplyService replyService = CreateReplyService();
                var replies = replyService.GetReplies();
                return Ok(replies);
            }

            public IHttpActionResult Post(ReplyCreate reply)
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var service = CreateReplyService();

                if (!service.CreateReply(reply))
                    return InternalServerError();

                return Ok();
            }
        }
}
