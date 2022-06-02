﻿
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Data.Dto
{
    public class CreateEnderecoDto
    {

        [Required(ErrorMessage = "Campo nome é obrigatorio")]
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }

    }
}