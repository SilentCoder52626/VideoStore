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
            CreateMap<Customer, CustomersDto>();

            CreateMap<MoviesGenre, MoviesGenreDto>();
            CreateMap<MembershipType, MembershipTypeDto>();

            

            CreateMap<Rental, Customer>();
            CreateMap<Customer , Rental>();

            CreateMap<Rental, Movies>();
            CreateMap<Movies, Rental>();


            // Dto to Domain
            CreateMap<CustomersDto, Customer>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            CreateMap<MoviesDto, Movie>()
                .ForMember(c => c.Id, opt => opt.Ignore());

            


        }
    }
}