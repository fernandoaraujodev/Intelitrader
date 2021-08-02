using GerenciandoUsuario_API.Domains.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace GerenciandoUsuario_API.Domains
{
    public class Usuario
    {

        [Key]
        public Guid Id { get; set; }


        [StringLength(40, ErrorMessage = "O nome deve ter entre 3 a 40 caracteres", MinimumLength = 3)]
        [Required(ErrorMessage = "O campo {0} não pode ficar em branco.")]
        public string Nome { get; set; }


        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1921-01-01", "2021-08-02", ErrorMessage = "Verifique a data de nascimento")]
        [Required(ErrorMessage = "O campo {0} não pode ficar em branco.")]
        public DateTime DataNascimento { get; set; }


        [Required(ErrorMessage = "O campo {0} não pode ficar em branco.")]
        [Range(1, 3)]
        public EnSexo Sexo { get; set; }
   

        public DateTime DataCriacao { get; set; }
        public DateTime DataAlteracao { get; set; }

        //Construtor
        public Usuario(string nome, DateTime dataNascimento, EnSexo sexo)
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
