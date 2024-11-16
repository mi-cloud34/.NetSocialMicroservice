using AutoMapper;
using MediatR;
using Message.Application.Features.Messages.Dtos;
using Message.Application.Services.Repositories;
using Message.Domain;

public class DeleteMessageCommand : IRequest<DeletedMessageDto>
{
    public int Id { get; set; }



    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, DeletedMessageDto>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;

        public DeleteMessageCommandHandler(IMessageRepository messageRepository, IMapper mapper)

        {
            _messageRepository = messageRepository;
            _mapper = mapper;

        }

        public async Task<DeletedMessageDto> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {

            Messagess mappedMessage = _mapper.Map<Messagess>(request);
            Messagess deletedMessage = await _messageRepository.DeleteAsync(mappedMessage);
            DeletedMessageDto deletedMessageDto = _mapper.Map<DeletedMessageDto>(deletedMessage);
            return deletedMessageDto;
        }
    }
}