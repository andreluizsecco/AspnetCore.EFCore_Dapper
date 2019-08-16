using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class AutorController : Controller
    {
        private readonly IAutorEFRepository _autorEFRepository;

        public AutorController(IAutorEFRepository autorEFRepository) =>
            _autorEFRepository = autorEFRepository;

        public IActionResult Index() =>
            View(_autorEFRepository.GetAll());

        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorEFRepository.GetById(id);
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

        // GET: Autor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorEFRepository.GetById(id);
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

        // GET: Autor/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorEFRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _autorEFRepository.GetById(id);
            _autorEFRepository.Remove(autor);
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id) =>
            _autorEFRepository.GetById(id) != null;

        private bool _disposed = false;

        ~AutorController() =>
            Dispose(false);

        protected override void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                _autorEFRepository.Dispose();
                base.Dispose(disposing);
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}
