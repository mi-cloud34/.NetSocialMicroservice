using AutoMapper;
using MediatR;
using Post.Application.Features.Posts.Dtos;
using Post.Application.Features.Posts.Model;
using Post.Application.Services.Repositories;
using Post.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Queries.GetPostByUserQuery
{
    public class GetListPostByUserQuery:IRequest<PostListModel>
    {
        public int UserId { get; set; }
        private class GetListPostByQueryHandler : IRequestHandler<GetListPostByUserQuery, PostListModel>
        {

            private readonly IPostRepository _postRepository;
            private readonly Mapper _mapper;

            public GetListPostByQueryHandler(IPostRepository postRepository, Mapper mapper)
            {
                _postRepository = postRepository;
                _mapper = mapper;
            }

            public async Task<PostListModel> Handle(GetListPostByUserQuery request, CancellationToken cancellationToken)
            {

                List<Postss> posts = (List<Postss>)await _postRepository.GetAllAsync(b=>b.UserId==request.UserId);
                PostListModel mappedPostListModel = _mapper.Map<PostListModel>(posts);
                return mappedPostListModel;

            }
        }
    }
}
