using AutoMapper;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Data;
using FilmesAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Controllers
{
    [ApiController]             
    [Route("[Controller]")]
    public class EnderecoController : ControllerBase
    {
        private FilmeContext _context;
        private IMapper _mapper;

        public EnderecoController(FilmeContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdcionarEndereco([FromBody] CreateEnderecoDtos createEnderecoDtos)
        {
            Endereco endereco = _mapper.Map<Endereco>(createEnderecoDtos);

            _context.Add(endereco);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = endereco.Id }, endereco);
        }

        [HttpGet]
        public IEnumerable<Endereco> RecuperarEndereco() => _context.Enderecos;



        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                ReadEnderecoDtos readEnderecoDtos = _mapper.Map<ReadEnderecoDtos>(endereco);
                return Ok();
            }

            return NotFound();

        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEnderecoId(int id, [FromBody] UpdateEnderecoDtos updateEnderecoDtos)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco == null)
                return NotFound();

            _mapper.Map<Endereco>(updateEnderecoDtos);

            endereco.Logradouro = updateEnderecoDtos.Logradouro;
            endereco.Bairro = updateEnderecoDtos.Bairro;
            endereco.Numero = updateEnderecoDtos.Numero;

            _context.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id}")]
        public IActionResult DeletarCinema(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            _context.Remove(endereco);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
