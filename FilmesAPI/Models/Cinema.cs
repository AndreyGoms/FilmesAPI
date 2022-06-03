﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesAPI.Models
{
    public class Cinema
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="Campo nome é obrigatorio")]
        public string Nome { get; set; }
        
        public Endereco endereco { get; set; }
        public int enderecoId { get; set; }
    }
}
