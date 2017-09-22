using AspnetCore.EFCore_Dapper.Data.Repositories.Dapper.Common;
using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.Dapper
{
    public class AutorDapperRepository : DapperRepositoryBase<Autor>, IAutorDapperRepository { }
}