using CRM.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Interfaces
{
    public interface IInstallation : IEntity
    {
        string Name { get; set; }
        string DatabaseName { get; }
        string FriendlyName { get; set; }
        int Port { get; set; }
        bool Secure { get; set; }
        Deployment Deployment { get; set; }
    }
}
