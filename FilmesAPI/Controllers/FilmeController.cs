using AutoMapper;
using FilmesAPI.Data;
using FilmesAPI.Data.Dto;
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
        public IActionResult AdicionarFilme([FromBody] CreateFilmeDto filmedto)
        {
            Filme filme = _mapper.Map<Filme>(filmedto);

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
                ReadFilmeDto readFilmeDto = _mapper.Map<ReadFilmeDto>(filme);
                return Ok(readFilmeDto);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilmeId(int id, [FromBody] UpdateFilmeDto updateFilmeDto)
        {
            Filme filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id);

            if (filme == null)
                return NotFound();
            
            _mapper.Map<Filme>(updateFilmeDto);
            //_mapper.Map(updateFilmeDto, filme);  ps: Forma alternativa

            filme.Titulo = updateFilmeDto.Titulo;
            filme.Diretor = updateFilmeDto.Diretor;
            filme.Duracao = updateFilmeDto.Duracao;
            filme.Genero = updateFilmeDto.Genero;

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
