using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dtos
{
    public class UpdateCinemaDtos
    {

        [Required(ErrorMessage = "Campo nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
