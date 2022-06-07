using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class FilmeProfile : Profile
    {
        //Cria-se o construtor que conterá os metodos de conversão
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDtos, Filme>();
            CreateMap<Filme, ReadFilmeDtos>();
            CreateMap<UpdateFilmeDtos, Filme>();
        }
    }
}
