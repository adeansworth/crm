using CRM.Data.Abstracts;
using CRM.Data.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Classes
{
    public class CoreDataContext : DataContextBase, IDisposable
    {
        public CoreDataContext() : base()
        {

        }

        public CoreDataContext(ProjectInstallation installation) : base(installation)
        {

        }

        private void Init()
        {
        }

        #region Collections
        public IMongoCollection<CoreInstallation> Installations { get { return base.GetCollection<CoreInstallation>(nameof(Installations).ToLower()); } }
        #endregion Collections

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
