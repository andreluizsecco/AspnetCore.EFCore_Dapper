using AspnetCore.EFCore_Dapper.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspnetCore.EFCore_Dapper.Data.Mappings.EntityFramework
{
    public class AutorMap: IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");

            builder.Property(p => p.ID)
                .ValueGeneratedNever();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar(100)")
                .IsRequired();

            builder.HasData(
                new Autor { ID = 1, Nome = "Eric Evans" },
                new Autor { ID = 2, Nome = "Robert C. Martin" },
                new Autor { ID = 3, Nome = "Vaughn Vernon" },
                new Autor { ID = 4, Nome = "Scott Millet" },
                new Autor { ID = 5, Nome = "Martin Fowler" }
            );
        }
    }
}