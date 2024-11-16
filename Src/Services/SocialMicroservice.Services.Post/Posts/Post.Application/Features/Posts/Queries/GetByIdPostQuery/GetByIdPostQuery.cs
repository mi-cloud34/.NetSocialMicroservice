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

namespace Post.Application.Features.Posts.Queries.GetByIdPostQuery
{
    public class GetByIdPostQuery : IRequest<PostDto>
    {
        public int Id { get; set; }
        private class GetPostQueryHandler : IRequestHandler<GetByIdPostQuery, PostDto>
        {
            private readonly IPostRepository _postRepository;
            private readonly Mapper _mapper;

            public GetPostQueryHandler(IPostRepository postRepository, Mapper mapper)
            {
                _postRepository = postRepository;
                _mapper = mapper;
            }

            public async Task<PostDto> Handle(GetByIdPostQuery request, CancellationToken cancellationToken)
            {

                Postss getByIdPost = await _postRepository.GetAsync(b => b.Id == request.Id);
                PostDto postDto = _mapper.Map<PostDto>(getByIdPost);
                return postDto;
            }
        }
    }
}
