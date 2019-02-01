using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoStore.Dtos;
using VideoStore.Models;

namespace VideoStore.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movies, MoviesDto>();
            CreateMap<MoviesGenre, MoviesGenreDto>();
            CreateMap<MembershipType, MembershipTypeDto>();
            CreateMap<MoviesGenre, MoviesGenreDto>();
        }
    }
}