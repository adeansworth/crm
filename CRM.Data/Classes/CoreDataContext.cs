using CRM.Data.Abstracts;
using CRM.Data.Entities;
using CRM.Shared.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Classes
{
    public class CoreDataContext : DataContextBase, IDisposable
    {
        public CoreDataContext()
        {
            SetupConnection(GetDefaultInstallation());
        }

        #region Collections
        public IMongoCollection<CoreInstallation> Installations { get { return base.GetCollection<CoreInstallation>(nameof(Installations).ToLower()); } }
        public IMongoCollection<CoreUser> Users { get { return base.GetCollection<CoreUser>(nameof(Users).ToLower()); } }
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
