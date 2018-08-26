using EstabelecimentosCategorias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstabelecimentosCategorias.ViewModel
{
    public class CategoriasViewModel
    {
        public IEnumerable<Categoria> Categorias { get; set; }
    }
}