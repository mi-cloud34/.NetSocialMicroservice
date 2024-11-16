using Message.Application.Services.Repositories;
using Message.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Services.SignalHub
{
    public class HubMessages : Hub
    {
        private readonly IMessageRepository _messageRepository;
        public HubMessages(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }
        public async Task SendMessage(string user, Messagess message)
        {
            message = new()
            {
                UserId = new BaseUserId().getIdFromRequest(),
                MessageText = message.MessageText
            };

            _messageRepository.AddAsync(message);


            await Clients.User(user).SendAsync("ReceiveMessage", JsonConvert.SerializeObject(message));

            // await Clients.User(Context.UserIdentifier).SendAsync("sendMessage",message);
        }
    }

}
