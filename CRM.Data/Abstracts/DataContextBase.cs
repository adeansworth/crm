using CRM.Data.Entities;
using CRM.Data.Interfaces;
using CRM.Shared.Abstracts;
using CRM.Shared.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Data.Abstracts
{
    public class DataContextBase : IDataContext, IDisposable
    {
        protected MongoClient Client { get; private set; }

        internal IMongoDatabase database = null;
        internal MongoClientSettings settings;

        protected IInstallation Installation { get; private set; }

        protected static IInstallation GetDefaultInstallation()
        {
            return new CoreInstallation()
            {
                Name = "Core"
            };
        }

        protected static IInstallation GetProjectInstallation(string name)
        {
            return new ProjectInstallation()
            {
                Name = name
            };
        }

        protected void SetupConnection(IInstallation installation = null)
        {
            if (installation != null)
                Installation = installation;
            else
                Installation = GetDefaultInstallation();

            settings = new MongoClientSettings()
            {
                Server = new MongoServerAddress(Installation.Server, Installation.Port),
                UseSsl = Installation.Secure
            };

            Client = new MongoClient(settings);
            database = Client.GetDatabase(Installation.DatabaseName);
        }

        public IMongoQueryable<T> GetQueryable<T>(string collectionName) => database.GetCollection<T>(collectionName).AsQueryable<T>();

        public IMongoCollection<T> GetCollection<T>(string collectionName) => database.GetCollection<T>(collectionName);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;
        }
    }
}
