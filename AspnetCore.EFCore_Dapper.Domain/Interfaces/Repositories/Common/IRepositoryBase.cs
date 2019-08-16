using System;
using System.Collections.Generic;

namespace AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories.Common
{
    public interface IRepositoryBase<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity obj);
        TEntity GetById(int? id);
        IEnumerable<TEntity> GetAll();
        void Update(TEntity obj);
        void Remove(TEntity obj);
    }
}
