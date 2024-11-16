using AutoMapper;
using MediatR;
using Message.Application.Features.Messages.Dtos;
using Message.Application.Services.Repositories;
using Message.Domain;

namespace Message.Application.Features.Messages.Queries.GetByIdMessage;

public class GetByIdMessageQuery : IRequest<MessageDto>
{
    public int Id { get; set; }

    public class GetByIdMessageQueryHandler : IRequestHandler<GetByIdMessageQuery, MessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public GetByIdMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper
                                      )
        {
            _messageRepository = messageRepository;
            _mapper = mapper;

        }


        public async Task<MessageDto> Handle(GetByIdMessageQuery request, CancellationToken cancellationToken)
        {

            Messagess message = await _messageRepository.GetAsync(b => b.Id == request.Id);
            MessageDto messageDto = _mapper.Map<MessageDto>(message);  
            return messageDto;
        }
    }
}