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
    
    public class ProjectInstallationRepository<T> : RepositoryBase<T> where T : ProjectInstallation
    {
        public ProjectInstallationRepository(IUnitOfWork unitOfWork, string databaseName) : base(unitOfWork, databaseName)
        {

        }

        public async override void Create(T entity)
        {
            await ProjectDataContext.Installations.InsertOneAsync(entity);
        }

        public async override void Delete(int id)
        {
            var filter = Builders<ProjectInstallation>.Filter.Eq(m => m.ID, id);
            await ProjectDataContext.Installations.FindOneAndDeleteAsync(filter);
        }
        
        public async override Task<T> Get(int id)
        {
            var filter = Builders<ProjectInstallation>.Filter.Eq(m => m.ID, id);
            var cursor = await ProjectDataContext.Installations.FindAsync<T>(filter);
            return cursor.FirstOrDefault();
        }

        public override IQueryable<T> GetAll()
        {
            return ProjectDataContext.GetQueryable<T>(CollectionName).AsQueryable();
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

            var result = await ProjectDataContext.Installations.ReplaceOneAsync(item => item.ID == entity.ID,
                (ProjectInstallation)entity, new UpdateOptions { IsUpsert = true });
        }
    }
}
