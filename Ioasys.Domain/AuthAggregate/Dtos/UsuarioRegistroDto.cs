﻿using System.ComponentModel.DataAnnotations;

namespace Ioasys.Domain.AuthAggregate.Dtos
{
    public class UsuarioRegistroDto
    {
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [MaxLength(150, ErrorMessage = "O campo nome deve conter no máximo 150 caracteres")]
        public string Nome { get; set; }
		
        [Required(ErrorMessage = "O campo Login é obrigatório")]
        [MaxLength(50, ErrorMessage = "O campo Login deve conter no máximo 50 caracteres")]
        public string Login { get; set; }
        
		[Required(ErrorMessage = "O senha campo é obrigatório")]        
        [MinLength(8, ErrorMessage = "O campo senha deve conter no mínimo 8 caracteres")]
		[MaxLength(20, ErrorMessage = "O campo senha deve conter no máximo 20 caracteres")]
        public string Senha { get; set; }
    }
}
