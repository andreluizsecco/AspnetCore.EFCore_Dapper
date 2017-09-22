using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.EFCore_Dapper.MVC.Controllers
{
    public class LivroHibridoController : Controller
    {
        private readonly ILivroEFRepository _livroEFRepository;
        private readonly IAutorEFRepository _autorEFRepository;
        private readonly ILivroDapperRepository _livroDapperRepository;
        private readonly IAutorDapperRepository _autorDapperRepository;

        public LivroHibridoController(ILivroEFRepository livroEFRepository,
                                      IAutorEFRepository autorEFRepository,
                                      ILivroDapperRepository livroDapperRepository,
                                      IAutorDapperRepository autorDapperRepository)
        {
            _livroEFRepository = livroEFRepository;
            _autorEFRepository = autorEFRepository;
            _livroDapperRepository = livroDapperRepository;
            _autorDapperRepository = autorDapperRepository;
        }

        // GET: Livro
        public IActionResult Index() =>
            View(_livroDapperRepository.GetAll());

        // GET: Livro/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroDapperRepository.GetById(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        // GET: Livro/Create
        public IActionResult Create()
        {
            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome");
            return View();
        }

        // POST: Livro/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ID,AutorID,Titulo,AnoPublicacao")] Livro livro)
        {
            if (ModelState.IsValid)
            {
                _livroEFRepository.Add(livro);
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        // GET: Livro/Edit/5
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

        // POST: Livro/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewData["AutorID"] = new SelectList(_autorDapperRepository.GetAll(), "ID", "Nome", livro.AutorID);
            return View(livro);
        }

        // GET: Livro/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            var livro = _livroDapperRepository.GetById(id);
            if (livro == null)
                return NotFound();

            return View(livro);
        }

        // POST: Livro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var livro = _livroDapperRepository.GetById(id);
            _livroEFRepository.Remove(livro);
            return RedirectToAction(nameof(Index));
        }

        private bool LivroExists(int id) =>
            _autorDapperRepository.GetById(id) != null;
    }
}
