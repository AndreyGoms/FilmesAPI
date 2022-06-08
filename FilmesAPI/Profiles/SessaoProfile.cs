﻿using AutoMapper;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<CreateSessaoDto, Sessao>();
            //CreateMap<Sessao, ReadSessaoDto>();
            CreateMap<Sessao, ReadSessaoDto>().
                ForMember(dto => dto.HorarioInicio, opts => opts
                .MapFrom(dto => dto.HorarioDeEncerramento.AddMinutes(dto.Filme.Duracao * (-1))));
        }
    }
}
