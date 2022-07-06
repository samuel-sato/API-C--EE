
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DesafioAPI.Model
{
    public class Profissional
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(300)]
        public string NomeCompleto { get; set; }
        [Required]
        public string CPF  { get; set; }
        [Required]
        public DateTime DataNascimento { get; set; }
        [Required]
        [MaxLength(1)]
        public string Sexo { get; set; }
        [Required]
        public bool Ativo { get; set; }
        [Required]
        [Index(IsUnique = true)]
        public int NumeroRegistro { get; set; }
        public string CEP { get; set; }
        [MaxLength(8)]
        public string Cidade { get; set; }
        public decimal ValorRenda { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }


        public override string ToString()
        {
            return $"ID {Id}, Nome: {NomeCompleto}, Numero Registro: {NumeroRegistro}, CPF:{CPF}";
        }

    }

    
}
