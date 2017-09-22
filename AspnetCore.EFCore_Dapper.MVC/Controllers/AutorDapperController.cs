using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class AutorDapperController : Controller
    {
        private readonly IAutorDapperRepository _autorDapperRepository;

        public AutorDapperController(IAutorDapperRepository autorDapperRepository) =>
            _autorDapperRepository = autorDapperRepository;

        // GET: Autor
        public IActionResult Index() =>
            View(_autorDapperRepository.GetAll());

        // GET: Autor/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorDapperRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        // GET: Autor/Create
        public IActionResult Create() =>
            View();

        // POST: Autor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,Nome")] Autor autor)
        {
            if (ModelState.IsValid)
            {
                _autorDapperRepository.Add(autor);
                return RedirectToAction(nameof(Index));
            }
            return View(autor);
        }

        // GET: Autor/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var autor = _autorDapperRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        // POST: Autor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
                    _autorDapperRepository.Update(autor);
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

            var autor = _autorDapperRepository.GetById(id);
            if (autor == null)
                return NotFound();

            return View(autor);
        }

        // POST: Autor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var autor = _autorDapperRepository.GetById(id);
            _autorDapperRepository.Remove(autor);
            return RedirectToAction(nameof(Index));
        }

        private bool AutorExists(int id) =>
            _autorDapperRepository.GetById(id) != null;
    }
}
