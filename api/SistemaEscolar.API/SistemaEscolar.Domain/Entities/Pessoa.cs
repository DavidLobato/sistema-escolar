
using System.ComponentModel.DataAnnotations;

namespace SistemaEscolar.Domain.Entities
{
    public class Pessoa
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telefone { get; set; } = string.Empty;
        [Required, MaxLength(15)]
        public string Celular { get; set; } = string.Empty;
        [Required]
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; } = string.Empty;
        public int Cep { get; set; }
        public string Endereco { get; set; } = string.Empty;
        public string Bairro { get; set; } = string.Empty;
        public int Numero { get; set; }

    }
}
