using AspnetCore.EFCore_Dapper.Domain.Entities;
using Dapper.FluentMap.Dommel.Mapping;

namespace AspnetCore.EFCore_Dapper.Data.Mappings.Dapper
{
    public class AutorDapperMap : DommelEntityMap<Autor>
    {
        public AutorDapperMap()
        {
            ToTable("Autor");
            Map(p => p.ID).IsKey();
        }
    }
}