using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
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
        public int enderecoId { get; set; }
        public virtual Endereco endereco { get; set; }
        //[JsonIgnore]
        public int gerenteID { get; set; }
        //[JsonIgnore]
        public virtual Gerente gerente { get; set; }
    }
}
