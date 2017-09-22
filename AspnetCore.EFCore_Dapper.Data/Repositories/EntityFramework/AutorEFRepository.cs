using AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework.Common;
using AspnetCore.EFCore_Dapper.Domain.Entities;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework
{
    public class AutorEFRepository : EFRepositoryBase<Autor>, IAutorEFRepository { }
}