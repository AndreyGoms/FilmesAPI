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
        private static List<Filme> filmes = new List<Filme>();
        private static int id = 0;


        [HttpPost]
        public void AdicionarFilme([FromBody] Filme filme)
        {
            filme.Id = id++;
            filmes.Add(filme);            
        }

        [HttpGet]
        public IEnumerable<Filme> RecuperarFilmes()
        {
            return filmes;
        }

        [HttpGet("{id}")]
        public Filme RecuperaFilmePorId(int id)
        {
            foreach(Filme filme in filmes)
            {
                if (filme.Id == id)
                    return filme;
            }
            return null;
        }
    }
}
