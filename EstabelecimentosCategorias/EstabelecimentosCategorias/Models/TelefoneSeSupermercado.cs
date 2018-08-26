using EstabelecimentosCategorias.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EstabelecimentosCategorias.Models
{
    public class TelefoneSeSupermercado : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var estabelecimento = (Estabelecimento)validationContext.ObjectInstance;
            if (estabelecimento.Categoria == null || String.IsNullOrWhiteSpace(estabelecimento.Categoria.Nome))
                return  ValidationResult.Success;
            if (estabelecimento.Categoria.Nome.ToLower() != "supermercado")
                return ValidationResult.Success;
            if (estabelecimento.Telefone == null )
                return new ValidationResult("Telefone obrigatorio para supermercados");
            return ValidationResult.Success;
        }
    }
}