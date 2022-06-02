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
        public IActionResult AdcionarCinema([FromBody] CreateCinemaDto cinemaDto)
        {
            Cinema cinema = _mapper.Map<Cinema>(cinemaDto);

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
                ReadCinemaDto readCinemaDto = _mapper.Map<ReadCinemaDto>(cinema);
                return Ok();
            }

            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinemaId(int id, [FromBody] UpdateCinemaDto updateCinemaDto)
        {
             Cinema cinema = _context.Cinemas.FirstOrDefault(cinema => cinema.Id == id);

            if (cinema == null)
                return NotFound();

            _mapper.Map<Cinema>(updateCinemaDto);

            cinema.Nome = updateCinemaDto.Nome;                      

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
