using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ApiCoreEF.Application.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é requirido")]
        [MinLength(2)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Login é requirido")]
        [MinLength(2)]
        [MaxLength(10)]
        public string Login { get; set; }

        [Required(ErrorMessage = "O Email é requirido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Senha é requirido")]
        [MinLength(2)]
        [MaxLength(50)]
        public string Senha { get; set; }
    }
}
