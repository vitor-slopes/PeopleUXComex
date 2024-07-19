using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PeopleUXComex.Core.Entities
{
    public class Person
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome não pode exceder 100 caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [Phone(ErrorMessage = "O telefone não é válido.")]
        [StringLength(15, ErrorMessage = "O telefone não pode exceder 15 caracteres.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(11, ErrorMessage = "O CPF deve ter 11 caracteres.")]
        public string CPF { get; set; }

        public ICollection<Address> Addresses { get; set; } = new List<Address>();
    }
}
