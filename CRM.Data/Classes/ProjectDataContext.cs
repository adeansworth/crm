﻿using CRM.Data.Abstracts;
using CRM.Data.Entities;
using CRM.Shared.Interfaces;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Classes
{
    public class ProjectDataContext : DataContextBase, IDisposable
    {
        public ProjectDataContext(string name)
        {
            SetupConnection(GetProjectInstallation(name));
        }

        public ProjectDataContext(IInstallation installation)
        {
            SetupConnection(installation);
        }

        #region Collections
        public IMongoCollection<ProjectInstallation> Installations { get { return base.GetCollection<ProjectInstallation>(nameof(Installations).ToLower()); } }
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
