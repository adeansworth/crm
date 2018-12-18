using CRM.Data.Abstracts;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
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

        }

        public async override void Create(T entity) 
        {
            await CoreDataContext.Installations.InsertOneAsync(entity);
        }

        public async override void Delete(int id)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID, id);
            await CoreDataContext.Installations.FindOneAndDeleteAsync(filter);
        }

        public async override Task<T> Get(int id)
        {
            var filter = Builders<CoreInstallation>.Filter.Eq(m => m.ID, id);
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

            if (entity.ID == 0)
            {
                Create(entity);
                return;
            }

            var result = await CoreDataContext.Installations.ReplaceOneAsync(item => item.ID == entity.ID,
                (CoreInstallation)entity, new UpdateOptions { IsUpsert = true });
        }
    }
}
