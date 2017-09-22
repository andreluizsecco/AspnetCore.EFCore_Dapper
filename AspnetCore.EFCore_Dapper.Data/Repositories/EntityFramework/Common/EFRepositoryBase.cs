using AspnetCore.EFCore_Dapper.Data.Context;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.EntityFramework.Common
{
    public class EFRepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AppDbContext db;

        public EFRepositoryBase()
        {
            db = new AppDbContext();
        }

        public virtual void Add(TEntity obj)
        {
            db.Add(obj);
            db.SaveChanges();
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return db.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(int? id)
        {
            return db.Set<TEntity>().Find(id);
        }

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

        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}