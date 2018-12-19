using CRM.Data.Abstracts;
using CRM.Data.Classes;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Repository
{
    public class CoreInstallationRepository<T> : RepositoryBase<T> where T : CoreInstallation
    {
        public CoreInstallationRepository(IUnitOfWork unitOfWork, string databaseName) : base(unitOfWork, databaseName)
        {
            //var indx = Builders<CoreInstallation>.IndexKeys.Ascending(m => m.Name);
            //CoreDataContext.Installations.Indexes.CreateOne(indx);

        }

        public async override void Create(T entity) 
        {
            await CoreDataContext.Installations.InsertOneAsync(entity);
        }

        public new async void CreateMany(IEnumerable<T> entities)
        {
            await CoreDataContext.Installations.InsertManyAsync(entities);
        }

        public async override void Delete(DocumentID id)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID, id);
            await CoreDataContext.Installations.FindOneAndDeleteAsync(filter);
        }

        public async override void Delete(string guid)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID.GUID, guid);
            await CoreDataContext.Installations.FindOneAndDeleteAsync(filter);
        }

        public async override void Delete(int id)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID.ID, id);
            await CoreDataContext.Installations.FindOneAndDeleteAsync(filter);
        }

        public async override Task<T> Get(DocumentID id)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID, id);
            var cursor = await CoreDataContext.Installations.FindAsync<T>(filter);
            return cursor.FirstOrDefault();
        }

        public async override Task<T> Get(string guid)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID.GUID, guid);
            var cursor = await CoreDataContext.Installations.FindAsync<T>(filter);
            return cursor.FirstOrDefault();
        }

        public async override Task<T> Get(int id)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID.ID, id);
            var cursor = await CoreDataContext.Installations.FindAsync<T>(filter);
            return cursor.FirstOrDefault();
        }

        public override IQueryable<T> GetAll()
        {
            return CoreDataContext.GetQueryable<T>(CollectionName).AsQueryable();
        }

        public async override void Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            var search = await Get(entity.Name);
            if (search == null)
                Create(entity);

            var result = await CoreDataContext.Installations.ReplaceOneAsync(item => item.ID.GUID == entity.ID.GUID,
                (CoreInstallation)entity, new UpdateOptions { IsUpsert = true });
        }
    }
}
