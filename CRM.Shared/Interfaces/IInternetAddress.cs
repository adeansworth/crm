using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Interfaces
{
    public interface IInternetAddress : IAddress
    {
        string Data { get; set; }
    }
}
