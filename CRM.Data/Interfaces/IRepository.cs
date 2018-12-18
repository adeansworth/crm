using CRM.Data.Abstracts;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces
{
    public interface IRepository<T> where  T : IEntity
    {
        IQueryable<T> GetAll();
        Task<T> Get(ObjectId id);
        void Create(T entity);
        void CreateMany(IEnumerable<T> entities);
        void Update(T entity);
        void UpdateMany(IEnumerable<T> entities);
        void Delete(ObjectId id);
        void DeleteMany(IEnumerable<T> entities);
    }
}
