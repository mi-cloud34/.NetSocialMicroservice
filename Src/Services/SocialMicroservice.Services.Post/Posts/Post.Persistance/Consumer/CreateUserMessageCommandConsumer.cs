using MassTransit;
using Post.Domain.Entities;
using Post.Persistance.Context;
using Social.AuthApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Commands.Consumer
{
    public class CreateUserMessageCommandConsumer : IConsumer<UpdateUserMessageeEvent>
    {
        private PostDbContext _postDbContext;
        public CreateUserMessageCommandConsumer(PostDbContext postDbContext)
        {
            _postDbContext = postDbContext;
        }

        public async Task Consume(ConsumeContext<UpdateUserMessageeEvent> consume)
        {
            var post = new Postss
            {
                User = new Users{

                    Name=consume.Message.Name,
                    SurName=consume.Message.SurName,
                    Email=consume.Message.Email,
                }
            };



            _postDbContext.Posts.Add(post);
            _postDbContext.SaveChanges();

        }
    }
}
