using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class LivroDapperController : Controller
    {
        private readonly ILivroDapperRepository _livroDapperRepository;
        private readonly IAutorDapperRepository _autorDapperRepository;

        public LivroDapperController(ILivroDapperRepository livroDapperRepository,
                                     IAutorDapperRepository autorDapperRepository)
        {
            _livroDapperRepository = livroDapperRepository;
            _autorDapperRepository = autorDapperRepository;
        }

        public IActionResult Index() =>
            View(_livroDapperRepository.GetAll());

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroDapperRepository.GetById(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        public IActionResult Create()
        {
            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,AutorID,Titulo,AnoPublicacao")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroDapperRepository.Add(livro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroDapperRepository.GetById(id);
            if (livro == null)
                return NotFound();

            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome", livro.AutorID);
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
                    _livroDapperRepository.Update(livro);
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
            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroDapperRepository.GetById(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var livro = _livroDapperRepository.GetById(id);
            _livroDapperRepository.Remove(livro);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id) =>
            _autorDapperRepository.GetById(id) != null;

        private bool _disposed = false;

        ~LivroDapperController() =>
            Dispose(false);

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _autorDapperRepository.Dispose();
                _livroDapperRepository.Dispose();
                base.Dispose(disposing);
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
