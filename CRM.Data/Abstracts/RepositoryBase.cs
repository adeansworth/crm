using CRM.Data.Classes;
using CRM.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Abstracts
{
    public abstract class RepositoryBase<T> : IRepository<T> where T : IEntity
    {
        public string CollectionName { get; set; }

        protected RepositoryBase(IUnitOfWork unitOfWork, string collectionName)
        {
            CoreDataContext = unitOfWork.CoreContext;
            ProjectDataContext = unitOfWork.ProjectContext;
            CollectionName = collectionName;

            if (CollectionName.StartsWith("project"))
                CollectionName = CollectionName.Substring(7);

            if (CollectionName.StartsWith("core"))
                CollectionName = CollectionName.Substring(4);
        }

        protected CoreDataContext CoreDataContext { get; private set; }
        protected ProjectDataContext ProjectDataContext { get; private set; }

        public abstract IQueryable<T> GetAll();
        public abstract Task<T> Get(ObjectId id);
        public abstract void Delete(ObjectId id);
        public abstract void Create(T entity);
        public void CreateMany(IEnumerable<T> entities) => entities.ToList().ForEach(m => { Create(m); });
        public abstract void Update(T entity);
        public void UpdateMany(IEnumerable<T> entities) => entities.ToList().ForEach(m => { /*Update(m);*/ });
        public void DeleteMany(IEnumerable<T> entities) => entities.ToList().ForEach(m => { /*Delete(m.ID);*/ });
    }
}
