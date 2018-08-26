using EstabelecimentosCategorias.Models;
using EstabelecimentosCategorias.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EstabelecimentosCategorias.Controllers
{
    public class CategoriasController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriasController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Categorias
        public ActionResult Index()
        {
            var categorias = _context.Categorias.ToList();

            var viewModel = new CategoriasViewModel
            {
                Categorias = categorias
            };

            return View(viewModel);
        }

        public ActionResult NovaCategoria()
        {
            return View("CategoriaForm", new Categoria());
        }

        public ActionResult Editar(int id)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.Id == id);

            if (categoria == null)
                return RedirectToAction("Index", "Categorias");

            return View("CategoriaForm", categoria);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(Categoria categoria)
        {
            if (!ModelState.IsValid)
                return View("CategoriaForm", categoria);

            if (categoria.Id == 0)
                _context.Categorias.Add(categoria);
            else
            {
                var categoriaInDb = _context.Categorias
                    .SingleOrDefault(c => c.Id == categoria.Id);

                categoriaInDb.Nome = categoria.Nome;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Categorias");
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {
            var categoria = _context.Categorias.SingleOrDefault(c => c.Id == id);

            if (categoria == null)
                return RedirectToAction("Index", "Categorias");

            var estabelecimentos = _context.Estabelecimentos
                .Where(e => e.CategoriaId == id)
                .ToList();

            foreach (var estabelecimento in estabelecimentos)
            {
                estabelecimento.CategoriaId = null;
            }

            _context.Categorias.Remove(categoria);
            _context.SaveChanges();

            return RedirectToAction("Index", "Categorias");
        }

    }
}