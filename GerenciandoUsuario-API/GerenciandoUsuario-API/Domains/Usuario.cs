using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciandoUsuario_API.Domains
{
    public class Usuario
    {

        [Key]
        public Guid Id { get; set; }

        [StringLength(40, ErrorMessage = "O nome deve ter entre 2 a 40 caracteres", MinimumLength = 3)]
        [Required]
        public string Nome { get; set; }

        [DataType(DataType.Date)]
        [Required]
        public DateTime DataNascimento { get; set; }


        [Required]
        public string Sexo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        //Construtor
        public Usuario(string nome, DateTime dataNascimento, string sexo)
        {


            Id = Guid.NewGuid();
            Nome = nome;
            DataNascimento = dataNascimento;
            Sexo = sexo;
            DataCriacao = DateTime.Now;
            DataAlteracao = DateTime.Now;
        }

        
    }
}
