using System;
using System.Linq;
using AspnetCore.EFCore_Dapper.Data.Context;
using AspnetCore.EFCore_Dapper.Domain.Entities;

namespace AspnetCore.EFCore_Dapper.Data.Data
{
    public static class DbInitializer
    {
        public static void Initialize()
        {
            var context = new AppDbContext();
            context.Database.EnsureCreated();

            if (context.Livros.Any())
            {
                return;   // Já contém dados
            }

            var autores = new Autor[]
            {
                new Autor { ID = 1, Nome = "Eric Evans" },
                new Autor { ID = 2, Nome = "Robert C. Martin" },
                new Autor { ID = 3, Nome = "Vaughn Vernon" },
                new Autor { ID = 4, Nome = "Scott Millet" },
                new Autor { ID = 5, Nome = "Martin Fowler" }
            };
            context.Autores.AddRange(autores);
            context.SaveChanges();

            var livros = new Livro[]
            {
                new Livro { AutorID = 1, Titulo = "Domain-Driven Design: Tackling Complexity in the Heart of Software", AnoPublicacao = 2003 },
                new Livro { AutorID = 2, Titulo = "Agile Principles, Patterns, and Practices in C#", AnoPublicacao = 2006 },
                new Livro { AutorID = 2, Titulo = "Clean Code: A Handbook of Agile Software Craftsmanship", AnoPublicacao = 2008 },
                new Livro { AutorID = 3, Titulo = "Implementing Domain-Driven Design",  AnoPublicacao = 2013 },
                new Livro { AutorID = 4, Titulo = "Patterns, Principles, and Practices of Domain-Driven Design", AnoPublicacao = 2015 },
                new Livro { AutorID = 5, Titulo = "Refactoring: Improving the Design of Existing Code ", AnoPublicacao = 2012 }
            };
            context.Livros.AddRange(livros);
            context.SaveChanges();
        }
    }
}