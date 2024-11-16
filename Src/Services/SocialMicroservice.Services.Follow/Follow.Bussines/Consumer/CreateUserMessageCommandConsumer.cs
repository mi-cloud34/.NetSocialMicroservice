using Follow.Bussines.Abstract;
using Follow.DataAcess.Concrete;
using MassTransit;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Social.Shared.Email;
using Social.Shared.Messages;

namespace Comment.WepAPI.Consumer
{
    public class CreateUserMessageCommandConsumer : IConsumer<UpdateUserMessageeEvent>
    {
       private FollowDbContext _context;
        public CreateUserMessageCommandConsumer(FollowDbContext followDbContext)
        {
            _context = followDbContext;
        }

        public async Task Consume(ConsumeContext<UpdateUserMessageeEvent> context)
        {
            var follow = new Follow.Entities.Follows{
                UserName=context.Message.Name,
                UserLastName=context.Message.SurName,
                UserMail=context.Message.Email
                
            };


           
         _context.Follows.Add(follow);
         _context.SaveChanges();
           
        }
    }
}
