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
        }
    }
}