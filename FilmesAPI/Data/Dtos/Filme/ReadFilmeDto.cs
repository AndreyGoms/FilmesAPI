using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class ReadFilmeDtos
    {
        [Key]
        [Required]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "O campo titulo é obrigatorio")] // obriga a preencher o campo
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O campo diretor é obrigatorio")]
        public string Diretor { get; set; }

        [StringLength(30, ErrorMessage = "genero = 30 char.")]
        public string Genero { get; set; }

        public int ClassificacaoEtaria { get; set; }

        [Range(1, 600, ErrorMessage = "Fora do intervalo")]
        public int Duracao { get; set; }

        DateTime HoraDaConsulta ;
    }
}
