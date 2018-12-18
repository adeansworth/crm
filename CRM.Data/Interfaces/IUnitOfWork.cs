using CRM.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        CoreDataContext CoreContext { get; }
        ProjectDataContext ProjectContext { get; }
    }
}
