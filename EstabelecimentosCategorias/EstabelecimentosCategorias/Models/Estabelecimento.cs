using System;
using System.ComponentModel.DataAnnotations;

namespace EstabelecimentosCategorias.Models
{
    public class Estabelecimento
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Display(Name = "Nome Fantasia")]
        public string NomeFantasia { get; set; }

        [Required]
        [ValidaCNPJ]
        public string CNPJ { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public string Cidade { get; set; }

        public string Estado { get; set; }

        [TelefoneSeSupermercado]
        public string Telefone { get; set; }

        [Display(Name = "Data de cadastro")]
        [DataType(DataType.DateTime)]
        public DateTime? DataCadastro { get; set; }

        public Categoria Categoria { get; set; }

        [Display(Name = "Categoria")]
        public int? CategoriaId { get; set; }

        public bool Status { get; set; }

        [Display(Name = "Agência")]
        public string Agencia { get; set; }

        public string Conta { get; set; }

    }
}