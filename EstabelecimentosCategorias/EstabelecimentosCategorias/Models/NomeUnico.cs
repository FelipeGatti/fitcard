using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace EstabelecimentosCategorias.Models
{
    public class NomeUnico : ValidationAttribute
    {
        private ApplicationDbContext _context;

        public NomeUnico()
        {
            _context = new ApplicationDbContext();
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var categoria = (Categoria)validationContext.ObjectInstance;
            var validaUnico = _context.Categorias
                .FirstOrDefault(c=>c.Nome == categoria.Nome 
                && c.Id != categoria.Id);

            if (validaUnico == null)
                return ValidationResult.Success;
            return new ValidationResult("Nome repetido!");

        }
    }
}