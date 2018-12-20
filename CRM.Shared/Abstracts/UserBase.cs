using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Abstracts
{
    public abstract class UserBase : PersonBase, IUser
    {
        public string Username { get; set; }
        public string InstallationID { get; set; }
        public IEnumerable<IAddress> Addresses { get; set; }
    }
}
