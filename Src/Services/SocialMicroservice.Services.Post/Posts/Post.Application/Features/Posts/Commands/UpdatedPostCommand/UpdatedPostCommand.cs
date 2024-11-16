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

namespace Post.Application.Features.Posts.Commands.UpdatedPostCommand
{
    public class UpdatedPostCommand:IRequest<UpdatePostDto>
    {
        private class UpdatePostCommandHandler : IRequestHandler<UpdatedPostCommand, UpdatePostDto>
        {
            private readonly IPostRepository _postRepository;
            private readonly Mapper _mapper;

            public UpdatePostCommandHandler(IPostRepository postRepository, Mapper mapper)
            {
                _postRepository = postRepository;
                _mapper = mapper;
            }
            public async Task<UpdatePostDto> Handle(UpdatedPostCommand request, CancellationToken cancellationToken)
            {
                Postss mappedPost = _mapper.Map<Postss>(request);
                Postss updatePost=await _postRepository.UpdateAsync(mappedPost);
                UpdatePostDto updatePostDto=_mapper.Map<UpdatePostDto>(updatePost);
                return updatePostDto;
              
            }
        }
    }
}
