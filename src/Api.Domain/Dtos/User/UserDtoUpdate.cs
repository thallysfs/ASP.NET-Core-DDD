using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [StringLength(60, ErrorMessage = "{0} deve ter no máxino {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "{0} é um campo obrigatório")]
        [EmailAddress(ErrorMessage = "Email em formato inválido")]
        [StringLength(100, ErrorMessage = "{0} deve ter no máxino {1} caracteres.")]
        public string Email { get; set; }
    }
}
