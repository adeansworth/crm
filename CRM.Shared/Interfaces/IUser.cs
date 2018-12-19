using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Interfaces
{
    public interface IUser : IPerson
    {
        string InstallationID { get; set; }
        string Username { get; set; }
    }
}
