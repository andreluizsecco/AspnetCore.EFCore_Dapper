using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class AutorHibridoController : Controller
    {
        private readonly IAutorEFRepository _autorEFRepository;
        private readonly IAutorDapperRepository _autorDapperRepository;

        public AutorHibridoController(IAutorEFRepository autorEFRepository,
                                      IAutorDapperRepository autorDapperRepository)
        {
            _autorEFRepository = autorEFRepository;
            _autorDapperRepository = autorDapperRepository;
        }

        public IActionResult Index() =>
            View(_autorDapperRepository.GetAll());

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorDapperRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        public IActionResult Create() =>
            View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Nome")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _autorEFRepository.Add(autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorDapperRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ID,Nome")] Autor autor)
        {
            if (id != autor.ID)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _autorEFRepository.Update(autor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutorExists(autor.ID))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorDapperRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _autorDapperRepository.GetById(id);
            _autorEFRepository.Remove(autor);
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id) =>
            _autorDapperRepository.GetById(id) != null;

        private bool _disposed = false;

        ~AutorHibridoController() =>
            Dispose(false);

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _autorEFRepository.Dispose();
                _autorDapperRepository.Dispose();
                base.Dispose(disposing);
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
