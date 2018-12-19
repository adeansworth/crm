using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Abstracts
{
    public abstract class User : Person, IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
