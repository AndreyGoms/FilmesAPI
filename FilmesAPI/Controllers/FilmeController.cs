using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]             // define a classe como controller
    [Route("[Controller]")]     // define a rota pela qual ela será chamada, no caso pelo nome do controller
    public class FilmeController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public FilmeController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        
        [HttpPost]
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDtos filmeDtos)
        {
            Filme filme = _mapper.Map<Filme>(filmeDtos);

            _context.Add(filme);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaFilmePorId), new { Id = filme.Id }, filme);
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes() => _context.Filmes;
        

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmePorId(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme != null)
            {
                ReadFilmeDtos readFilmeDtos = _mapper.Map<ReadFilmeDtos>(filme);
                return Ok(readFilmeDtos);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmeId(int id, [FromBody] UpdateFilmeDtos updateFilmeDtos)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
                return NotFound();
            
            _mapper.Map<Filme>(updateFilmeDtos);
            //_mapper.Map(updateFilmeDtos, filme);  ps: Forma alternativa

            filme.Titulo = updateFilmeDtos.Titulo;
            filme.Diretor = updateFilmeDtos.Diretor;
            filme.Duracao = updateFilmeDtos.Duracao;
            filme.Genero = updateFilmeDtos.Genero;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            _context.Remove(filme);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
