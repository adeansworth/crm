using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Interfaces
{
    public interface IUser : IPerson
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
