using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDtos, Gerente>();
            //---- Opcao utilizando [JsonIgnore] em "Gerente" e "gerenteid" na classe Cinema
            //CreateMap<Gerente, ReadGerenteDtos>(); 

            CreateMap<Gerente, ReadGerenteDtos>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas.Select
                (c => new { c.Id, c.Nome, c.endereco, c.enderecoId })));
        }
    }
}
