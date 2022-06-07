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
    [Controller]
    [Route("[Controller]")]
    public class CinemaController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public CinemaController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdcionarCinema([FromBody] CreateCinemaDtos cinemaDtos)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDtos);

            _context.Add(cinema);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = cinema.Id }, cinema);
        }

        [HttpGet]
        public IEnumerable<Cinema> RecuperarCinemas() => _context.Cinemas;


        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if ( cinema != null)
            {
                ReadCinemaDtos readCinemaDtos = _mapper.Map<ReadCinemaDtos>(cinema);
                return Ok(readCinemaDtos);
            }

            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinemaId(int id, [FromBody] UpdateCinemaDtos updateCinemaDtos)
        {
             Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
                return NotFound();

            _mapper.Map<Cinema>(updateCinemaDtos);

            cinema.Nome = updateCinemaDtos.Nome;                      

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            _context.Remove(cinema);
            _context.SaveChanges();

            return NoContent();
        }


    }
}
