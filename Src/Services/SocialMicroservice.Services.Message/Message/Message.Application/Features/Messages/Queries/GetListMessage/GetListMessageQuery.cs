using AutoMapper;
using MediatR;
using Message.Application.Features.Messages.Models;
using Message.Application.Services.Repositories;
using Message.Domain;

namespace Message.Application.Features.Messages.Queries.GetListMessage;

public class GetListMessageQuery : IRequest<MessageListModel>
{

    public class GetListMessageQueryHandler : IRequestHandler<GetListMessageQuery, MessageListModel>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetListMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
        }

        public async Task<MessageListModel> Handle(GetListMessageQuery request, CancellationToken cancellationToken)
        {
            List<Messagess?> Messages = (List<Messagess?>)await _messageRepository.GetAllAsync();
            MessageListModel mappedMessageListModel = _mapper.Map<MessageListModel>(Messages);
            return mappedMessageListModel;
        }
    }
}