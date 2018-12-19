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
        public abstract Task<T> Get(DocumentID id);
        public abstract Task<T> Get(string guid);
        public abstract Task<T> Get(int id);
        public abstract void Create(T entity);
        public void CreateMany(IEnumerable<T> entities) { }
        public abstract void Update(T entity);
        public void UpdateMany(IEnumerable<T> entities) { }
        public abstract void Delete(DocumentID id);
        public abstract void Delete(string guid);
        public abstract void Delete(int id);
        public void DeleteMany(IEnumerable<T> entities) { }
    }
}
