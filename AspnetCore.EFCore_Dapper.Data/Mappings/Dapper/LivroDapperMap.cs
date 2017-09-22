using AspnetCore.EFCore_Dapper.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace AspnetCore.EFCore_Dapper.Data.Mappings.Dapper
{
    public class LivroDapperMap : DommelEntityMap<Livro>
    {
        public LivroDapperMap()
        {
            ToTable("Livro");
            Map(p => p.ID).IsKey().IsIdentity();
        }
    }
}