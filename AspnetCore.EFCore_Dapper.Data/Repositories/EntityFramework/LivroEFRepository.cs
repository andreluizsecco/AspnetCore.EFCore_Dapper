using AspnetCore.EFCore_Dapper.Data.Context;
using AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework.Common;
using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework
{
    public class LivroEFRepository : EFRepositoryBase<Livro>, ILivroEFRepository
    {
        public LivroEFRepository(AppDbContext context) : base(context) { }

        public override IEnumerable<Livro> GetAll() =>
            db.Livros.Include(x => x.Autor).ToList();

        public override Livro GetById(int? id) =>
            db.Livros.Include(x => x.Autor).FirstOrDefault(x => x.ID == id);
    }
}