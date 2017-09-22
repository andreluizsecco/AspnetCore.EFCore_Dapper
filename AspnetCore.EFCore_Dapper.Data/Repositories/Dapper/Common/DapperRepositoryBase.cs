using AspnetCore.EFCore_Dapper.Data.Mappings.Dapper;
using AspnetCore.EFCore_Dapper.Domain.Interfaces.Repositories.Common;
using Dapper.FluentMap;
using Dapper.FluentMap.Dommel;
using Dommel;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;

namespace AspnetCore.EFCore_Dapper.Data.Repositories.Dapper.Common
{
    public class DapperRepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly SqlConnection conn;

        public DapperRepositoryBase()
        {
            if (FluentMapper.EntityMaps.IsEmpty)
            {
                FluentMapper.Initialize(c =>
                {
                    c.AddMap(new LivroDapperMap());
                    c.AddMap(new AutorDapperMap());
                    c.ForDommel();
                });
            }

            var config =  new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            
            conn = new SqlConnection(config.GetConnectionString("DefaultConnection"));
        }

        public void Add(TEntity obj)
        {
            conn.Insert(obj);
        }        

        public virtual IEnumerable<TEntity> GetAll()
        {
            return conn.GetAll<TEntity>();
        }

        public virtual TEntity GetById(int? id)
        {
            return conn.Get<TEntity>(id);
        }

        public virtual void Remove(TEntity obj)
        {
            conn.Delete(obj);
        }

        public virtual void Update(TEntity obj)
        {
            conn.Update(obj);
        }

        public void Dispose()
        {
            conn.Close();
            conn.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}