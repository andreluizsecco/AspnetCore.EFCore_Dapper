using AspnetCore.EFCore_Dapper.Data.Repositories.Dapper.Common;
using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;
using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.Dapper
{
    public class LivroDapperRepository : DapperRepositoryBase<Livro>, ILivroDapperRepository
    {
        public LivroDapperRepository(IConfiguration configuration) : base(configuration) { }

        public override IEnumerable<Livro> GetAll() =>
            conn.Query<Livro, Autor, Livro>(
                @"SELECT * FROM Livro INNER JOIN Autor ON Livro.AutorID = Autor.ID",
                map: (livro, autor) => 
                {
                    livro.Autor = autor;
                    return livro; 
                });

        public override Livro GetById(int? id) =>
            conn.Query<Livro, Autor, Livro>(
                @"SELECT TOP(1) * FROM Livro INNER JOIN Autor ON Livro.AutorID = Autor.ID WHERE Livro.ID = @livroID",
                map: (livro, autor) => 
                {
                    livro.Autor = autor;
                    return livro; 
                },
                param: new { livroID = id }).FirstOrDefault();
    }
}