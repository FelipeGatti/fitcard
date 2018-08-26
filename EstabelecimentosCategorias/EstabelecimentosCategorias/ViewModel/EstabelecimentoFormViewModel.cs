using EstabelecimentosCategorias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstabelecimentosCategorias.ViewModel
{
    public class EstabelecimentoFormViewModel
    {
        public Estabelecimento Estabelecimento { get; set; }

        public List<Categoria> Categorias { get; set; }


        public static List<string> TransformarEmString(List<Categoria> categorias)
        {
            var listaStringCategorias = new List<string>();
            foreach (var categoria in categorias)
            {
                listaStringCategorias.Add(categoria.Nome);
            }
            return listaStringCategorias;
        }
    }
}