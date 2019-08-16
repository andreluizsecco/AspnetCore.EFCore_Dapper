using AspnetCore.EFCore_Dapper.Data.Mappings.EntityFramework;
using AspnetCore.EFCore_Dapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AspnetCore.EFCore_Dapper.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) =>
            Database.EnsureCreated();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new LivroMap());
            modelBuilder.ApplyConfiguration(new AutorMap());
        }

        public DbSet<Livro> Livros { get; set; }
        public DbSet<Autor> Autores { get; set; }
    }
}