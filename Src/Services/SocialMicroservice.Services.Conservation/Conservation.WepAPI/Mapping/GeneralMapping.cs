using AutoMapper;
using Conservation.WepAPI.Dto;
using Conservation.WepAPI.Model;
using MongoDB.Driver.Core.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Conservation.WepAPI.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Conservations, ConservationDto>().ReverseMap();
            CreateMap<Conservations, ConservationDeleteDto>().ReverseMap();
            CreateMap<Conservations,ConservationCreateDto>().ReverseMap();

        }
    }
}