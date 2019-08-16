using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroEFRepository _livroEFRepository;
        private readonly IAutorEFRepository _autorEFRepository;

        public LivroController(ILivroEFRepository livroEFRepository,
                               IAutorEFRepository autorEFRepository)
        {
            _livroEFRepository = livroEFRepository;
            _autorEFRepository = autorEFRepository;
        }

        public IActionResult Index() =>
            View(_livroEFRepository.GetAll());

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroEFRepository.GetById(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        public IActionResult Create()
        {
            ViewData["AutorID"] = new SelectList(_autorEFRepository.GetAll(), "ID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,AutorID,Titulo,AnoPublicacao")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroEFRepository.Add(livro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorID"] = new SelectList(_autorEFRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroEFRepository.GetById(id);
            if (livro == null)
                return NotFound();

            ViewData["AutorID"] = new SelectList(_autorEFRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,AutorID,Titulo,AnoPublicacao")] Livro livro)
        {
            if (id != livro.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _livroEFRepository.Update(livro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LivroExists(livro.ID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorID"] = new SelectList(_autorEFRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroEFRepository.GetById(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var livro = _livroEFRepository.GetById(id);
            _livroEFRepository.Remove(livro);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id) =>
            _autorEFRepository.GetById(id) != null;

        private bool _disposed = false;

        ~LivroController() =>
            Dispose(false);

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _autorEFRepository.Dispose();
                _livroEFRepository.Dispose();
                base.Dispose(disposing);
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
