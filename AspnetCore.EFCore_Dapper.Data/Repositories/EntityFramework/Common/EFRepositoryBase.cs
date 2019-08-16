using AspnetCore.EFCore_Dapper.Data.Context;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework.Common
{
    public abstract class EFRepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AppDbContext db;

        public EFRepositoryBase(AppDbContext context) =>
            db = context;

        public virtual void Add(TEntity obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll() =>
            db.Set<TEntity>().ToList();

        public virtual TEntity GetById(int? id) =>
            db.Set<TEntity>().Find(id);

        public virtual void Remove(TEntity obj)
        {
            db.Set<TEntity>().Remove(obj);
            db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }

        private bool _disposed = false;

        ~EFRepositoryBase() =>
            Dispose();

        public void Dispose()
        {
            if (!_disposed)
            {
                db.Dispose();
                _disposed = true;
            }
            GC.SuppressFinalize(this);
        }
    }
}