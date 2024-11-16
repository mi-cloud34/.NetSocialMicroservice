using AutoMapper;
using MediatR;
using Post.Application.Features.Posts.Dtos;
using Post.Application.Services.Repositories;
using Post.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Commands.DeletePostCommand
{
    public class DeletePostCommand:IRequest<DeletedPostDto>
    {
        public int Id { get; set; }
        public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletedPostDto>
        {
            private readonly IPostRepository _postRepository;
            private readonly Mapper _mapper;

            public DeletePostCommandHandler(IPostRepository postRepository, Mapper mapper)
            {
                _postRepository = postRepository;
                _mapper = mapper;
            }

            public async Task<DeletedPostDto> Handle(DeletePostCommand request, CancellationToken cancellationToken)
            {
                Postss mappedPost=_mapper.Map<Postss>(request.Id);
                Postss deletePosts =await  _postRepository.DeleteAsync(mappedPost);
                DeletedPostDto deletedPostDto=_mapper.Map<DeletedPostDto>(deletePosts);
                return deletedPostDto;
            }
        }
    }
}
