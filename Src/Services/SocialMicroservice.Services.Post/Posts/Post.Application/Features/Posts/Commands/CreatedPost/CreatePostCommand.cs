using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Post.Application.Features.Posts.Dtos;
using Post.Application.Services.Repositories;
using Post.Domain.Entities;
using Social.Shared.FileShared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Commands.CreatedPost
{
    public class CreatePostCommand : IRequest< CreatedPostDto>
    {
        public IFormFile? Files { get; set; }
        public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatedPostDto>
        {
            private readonly IMapper _mapper;
            private readonly IPostRepository _postRepository;
            private readonly IStorageService _storageServices;

            public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IStorageService storageServices)
            {
                _mapper = mapper;
                _postRepository = postRepository;
                _storageServices = storageServices;
            }

            public async Task<CreatedPostDto> Handle(CreatePostCommand request, CancellationToken cancellationToken)
            {
                Postss  mappedPost = _mapper.Map<Postss>(request);
                (string fileName, string pathOrContainerName) result = await _storageServices.UploadAsync("post-files", request.Files);
                mappedPost.PostImages = new Collection<ImageFiles>()
            {
                new ImageFiles(){
                    Name = result.fileName,
                Path = result.pathOrContainerName,
                Storage = _storageServices.StorageName,
              
                }
            };
                Postss createPosts= await _postRepository.AddAsync(mappedPost);
                CreatedPostDto postDto= _mapper.Map<CreatedPostDto>(createPosts);
                return postDto;
            }
        }

    }
}
