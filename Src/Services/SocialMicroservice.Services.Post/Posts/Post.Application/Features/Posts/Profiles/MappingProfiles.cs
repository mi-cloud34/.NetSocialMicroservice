using AutoMapper;
using Post.Application.Features.Posts.Commands.CreatedPost;
using Post.Application.Features.Posts.Commands.DeletePostCommand;
using Post.Application.Features.Posts.Commands.UpdatedPostCommand;
using Post.Application.Features.Posts.Dtos;
using Post.Application.Features.Posts.Model;
using Post.Domain.Entities;
using Social.AuthAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Post.Application.Features.Posts.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Postss, CreatePostCommand>().ReverseMap();
            CreateMap<Postss, CreatedPostDto>().ReverseMap();
            CreateMap<Postss, UpdatedPostCommand>().ReverseMap();
            CreateMap<Postss, UpdatePostDto>().ReverseMap();
            CreateMap<Postss, DeletePostCommand>().ReverseMap();
            CreateMap<Postss, DeletedPostDto>().ReverseMap();
            CreateMap<Postss, PostDto>().ReverseMap();
            CreateMap<Postss, PostListDto>();
            CreateMap<Postss, PostListModel>().ReverseMap();
        }
    }
}
