using AutoMapper;
using MovieApp.Application.Dto;
using MovieApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MovieApp.Api.Core.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MovieDto, Movie>()
                .ForMember(x => x.GenresLinks, opt => opt.Ignore())
                .ForMember(x => x.ActorsLinks, opt => opt.Ignore());
        }
    }
}
