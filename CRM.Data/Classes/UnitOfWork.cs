using CRM.Data.Entities;
using CRM.Data.Interfaces;
using CRM.Data.Repository;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Classes
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly CoreDataContext _coreContext;
        private readonly ProjectDataContext _projectContext;

        public UnitOfWork(CoreDataContext coreDataContext = null, ProjectDataContext projectDataContext = null)
        {
            if (coreDataContext == null)
                coreDataContext = new CoreDataContext();

            _coreContext = coreDataContext;

            if (projectDataContext != null)
                _projectContext = projectDataContext;
        }

        CoreDataContext IUnitOfWork.CoreContext { get { return _coreContext; } }
        ProjectDataContext IUnitOfWork.ProjectContext { get { return _projectContext; } }
        
        void IDisposable.Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!disposing) return;

            if (_coreContext == null) return;

            _coreContext.Dispose();
        }

        #region CoreContext
        private CoreInstallationRepository<CoreInstallation> coreInstallations;
        public CoreInstallationRepository<CoreInstallation> CoreInstallations { get { if (coreInstallations == null) { coreInstallations = new CoreInstallationRepository<CoreInstallation>(this, nameof(coreInstallations).ToLower()); } return coreInstallations; } }
        #endregion CoreContext
        #region ProjectContext
        private ProjectInstallationRepository<ProjectInstallation> projectInstallations;
        public ProjectInstallationRepository<ProjectInstallation> ProjectInstallations { get { if(projectInstallations == null) { projectInstallations = new ProjectInstallationRepository<ProjectInstallation>(this, nameof(projectInstallations).ToLower()); } return projectInstallations; } }
        #endregion ProjectContext

    }
}
