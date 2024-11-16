using AutoMapper;
using MediatR;
using Post.Application.Features.Posts.Model;
using Post.Application.Services.Repositories;
using Post.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Queries.GetListPostQuery
{
    public class GetListPostQuery : IRequest<PostListModel>
    {
      

        public class GetListPostQueryHandler : IRequestHandler<GetListPostQuery, PostListModel>
        {
            private readonly IPostRepository _postRepository;
            private readonly IMapper _mapper;

            public GetListPostQueryHandler(IPostRepository postRepository, IMapper mapper)
            {
                _postRepository = postRepository;
                _mapper = mapper;
            }

            public async Task<PostListModel> Handle(GetListPostQuery request, CancellationToken cancellationToken)
            {
                List<Postss> posts = (List<Postss>) await _postRepository.GetAllAsync();
                PostListModel mappedPostListModel = _mapper.Map<PostListModel>(posts);
                return mappedPostListModel;
            }
        }
    }
}
