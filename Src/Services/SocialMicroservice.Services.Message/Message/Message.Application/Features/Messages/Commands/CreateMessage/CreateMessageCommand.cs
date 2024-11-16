using AutoMapper;
using MediatR;
using Message.Application.Features.Messages.Dtos;
using Message.Application.Services.Repositories;
using Message.Domain;
using Microsoft.AspNetCore.Http;
using Social.Shared.FileShared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Message.Application.Features.Messages.Commands.CreateMessage
{
    public class CreateMessageCommand : IRequest<CreatedMessageDto>
    {
        public IFormFile? File { get; set; }
        public class CreatePostCommandHandler : IRequestHandler<CreateMessageCommand, CreatedMessageDto>
        {
            IMessageRepository _messageRepository;
            private readonly IMapper _mapper;
            private readonly IStorageService _storageServices;
            public CreatePostCommandHandler(IMessageRepository messageRepository, IMapper mapper, IStorageService storageServices)
            {
                _messageRepository = messageRepository;
                _mapper = mapper;
                _storageServices = storageServices;
            }

            public async Task<CreatedMessageDto> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {
                Messagess mappedMessage = _mapper.Map<Messagess>(request);
                (string fileName, string pathOrContainerName) result =
                 await _storageServices.UploadAsync("message-images", request.File);
                //  FileShare=== public IFormCollection? Files { get; set; }
                mappedMessage.Photo = new()
                {


                    Name = result.fileName,
                    Path = result.pathOrContainerName,
                    Storage = _storageServices.StorageName,

                };
                Messagess createMessage = await _messageRepository.AddAsync(mappedMessage);
                CreatedMessageDto createdPostDto = _mapper.Map<CreatedMessageDto>(createMessage);
                return createdPostDto;

            }
        }
    }
}
