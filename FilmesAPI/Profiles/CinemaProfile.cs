using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class CinemaProfile : Profile
    {
        public CinemaProfile()
        {
            CreateMap<CreateCinemaDtos, Cinema>();
            CreateMap<Cinema, ReadCinemaDtos>();
            CreateMap<UpdateCinemaDtos, Cinema>();
        }
    }
}
