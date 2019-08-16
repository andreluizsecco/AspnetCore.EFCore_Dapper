using AspnetCore.EFCore_Dapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetCore.EFCore_Dapper.Data.Mappings.EntityFramework
{
    public class LivroMap: IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.Property(p => p.ID)
                .ValueGeneratedOnAdd();

            builder.Property(p => p.Titulo)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasOne(p => p.Autor)
                .WithMany(p => p.Livros)
                .HasForeignKey(p => p.AutorID);

            builder.HasData(
                new Livro { ID = 1, AutorID = 1, Titulo = "Domain-Driven Design: Tackling Complexity in the Heart of Software", AnoPublicacao = 2003 },
                new Livro { ID = 2, AutorID = 2, Titulo = "Agile Principles, Patterns, and Practices in C#", AnoPublicacao = 2006 },
                new Livro { ID = 3, AutorID = 2, Titulo = "Clean Code: A Handbook of Agile Software Craftsmanship", AnoPublicacao = 2008 },
                new Livro { ID = 4, AutorID = 3, Titulo = "Implementing Domain-Driven Design", AnoPublicacao = 2013 },
                new Livro { ID = 5, AutorID = 4, Titulo = "Patterns, Principles, and Practices of Domain-Driven Design", AnoPublicacao = 2015 },
                new Livro { ID = 6, AutorID = 5, Titulo = "Refactoring: Improving the Design of Existing Code ", AnoPublicacao = 2012 }
            );
        }
    }
}