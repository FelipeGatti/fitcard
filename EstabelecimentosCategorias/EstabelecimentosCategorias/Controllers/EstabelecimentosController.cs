using EstabelecimentosCategorias.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EstabelecimentosCategorias.ViewModel;

namespace EstabelecimentosCategorias.Controllers
{
    public class EstabelecimentosController : Controller
    {
        private ApplicationDbContext _context;

        public EstabelecimentosController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
            // GET: Estabelecimentos
        public ActionResult Index()
        {
            var estabelecimentos = _context.Estabelecimentos.Include(e => e.Categoria).ToList();

            var viewModel = new EstabelecimentosViewModel
            {
                Estabelecimentos = estabelecimentos
            };
            return View(viewModel);
        }

        public ActionResult NovoEstabelecimento()
        {
            var viewModel = new EstabelecimentoFormViewModel
            {
                Categorias = _context.Categorias.ToList(),
                Estabelecimento = new Estabelecimento()
            };
            return View("EstabelecimentoForm",viewModel);
        }

        public ActionResult Editar(int id)
        {
            var estabelecimento = _context.Estabelecimentos.SingleOrDefault(e => e.Id == id);

            if (estabelecimento == null)
                return RedirectToAction("Index", "Estabelecimentos");

            var categorias = _context.Categorias.ToList();

            var listaStringCategorias = EstabelecimentoFormViewModel.TransformarEmString(categorias);

            var viewModel = new EstabelecimentoFormViewModel
            {
                Categorias = _context.Categorias.ToList(),
                Estabelecimento = estabelecimento
            };
            return View("EstabelecimentoForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Salvar(Estabelecimento estabelecimento)
        {
            ModelState.Remove("estabelecimento.Categoria.Nome");
            if (!ModelState.IsValid)
            {
                var viewModel = new EstabelecimentoFormViewModel
                {
                    Estabelecimento = estabelecimento,
                    Categorias = _context.Categorias.ToList(),
                };
                return View("EstabelecimentoForm", viewModel);
            }

            int? categoriaId = 0;
            if (!String.IsNullOrWhiteSpace(estabelecimento.Categoria.Nome))
            {
                categoriaId = _context.Categorias.
                    SingleOrDefault(c => c.Nome == estabelecimento.Categoria.Nome).Id;
            }
            estabelecimento.Categoria = null;

            if (categoriaId == 0)
                categoriaId = null;

            if (estabelecimento.Id == 0)
            {
                estabelecimento.CategoriaId = categoriaId;
                _context.Estabelecimentos.Add(estabelecimento);
            }
            else
            {
                var estabelecimentoInDb = _context.Estabelecimentos.
                    Single(e => e.Id == estabelecimento.Id);

                estabelecimentoInDb.Agencia = estabelecimento.Agencia;
                estabelecimentoInDb.CategoriaId = categoriaId;
                estabelecimentoInDb.Cidade = estabelecimento.Cidade;
                estabelecimentoInDb.CNPJ = estabelecimento.CNPJ;
                estabelecimentoInDb.Conta = estabelecimento.Conta;
                estabelecimentoInDb.DataCadastro = estabelecimento.DataCadastro;
                estabelecimentoInDb.Email = estabelecimento.Email;
                estabelecimentoInDb.Endereco = estabelecimento.Endereco;
                estabelecimentoInDb.Estado = estabelecimento.Estado;
                estabelecimentoInDb.NomeFantasia = estabelecimento.NomeFantasia;
                estabelecimentoInDb.RazaoSocial = estabelecimento.RazaoSocial;
                estabelecimentoInDb.Status = estabelecimento.Status;
                estabelecimentoInDb.Telefone = estabelecimento.Telefone;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Estabelecimentos");
        }

        [HttpDelete]
        [ValidateAntiForgeryToken]
        public ActionResult Deletar(int id)
        {
            var estabelecimento = _context.Estabelecimentos.SingleOrDefault(e => e.Id == id);

            if (estabelecimento == null)
                return RedirectToAction("Index", "Estabelecimentos");

            _context.Estabelecimentos.Remove(estabelecimento);
            _context.SaveChanges();

            return RedirectToAction("Index", "Estabelecimentos");
        }
    }
}