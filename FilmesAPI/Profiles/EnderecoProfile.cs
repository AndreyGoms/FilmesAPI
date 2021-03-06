using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDtos, Endereco>();
            CreateMap<Endereco, ReadEnderecoDtos>();
            CreateMap<UpdateEnderecoDtos, Endereco>();

        }
    }
}
