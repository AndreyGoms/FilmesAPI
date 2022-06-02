using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo nome é obrigatorio")]
        public string Nome { get; set; }
    }
}
