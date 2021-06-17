using AutoMapper;
using MovieShop.Application.Dto;
using MovieShop.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace MovieShop.Implementation.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDtoShow>()
            .ForMember(dto => dto.Genres, opt => opt.MapFrom(movie => movie.GenresLinks.Select(ol => ol.Genre).ToList()));
        }
    }
}
