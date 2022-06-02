using System.ComponentModel.DataAnnotations;

namespace FilmesAPI.Data.Dto
{
    public class CreateCinemaDto
    {

        [Required(ErrorMessage = "Campo nome é obrigatorio")]
        public string Nome { get; set; }

    }
}
