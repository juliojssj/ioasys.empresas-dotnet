using System.ComponentModel.DataAnnotations;

namespace Ioasys.Domain.AuthAggregate.Dtos
{
    public class LoginDto
    {
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Login deve conter no maximo 50 caracteres")]
        public string Login { get; set; }
        
		[Required(ErrorMessage = "O campo senha é obrigatório")]
        [MaxLength(20, ErrorMessage = "O campo senha deve conter no maximo 20 caracteres")]
        [MinLength(8, ErrorMessage = "O campo senha deve conter no minimo 8 caracteres")]
        public string Senha { get; set; }
    }
}
