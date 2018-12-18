using CRM.Data.Entities;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CRM.Data.Abstracts
{
    public class DataContextBase : IDisposable
    {
        protected MongoClient Client { get; private set; }

        internal IMongoDatabase database = null;
        internal MongoClientSettings settings;

        protected ProjectInstallation Installation { get; private set; }

        public DataContextBase()
        {
            SetupConnection();
        }

        public DataContextBase(ProjectInstallation installation)
        {
            SetupConnection(installation);
        }

        private ProjectInstallation GetDefaultInstallation()
        {
            return new ProjectInstallation()
            {
                Name = "Core"
            };
        }

        private void SetupConnection(ProjectInstallation installation = null)
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

        public void ChangeProjectToDefault() => SetupConnection(GetDefaultInstallation());

        public void ChangeProject(ProjectInstallation installation) => SetupConnection(installation);

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
