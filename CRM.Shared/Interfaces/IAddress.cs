using CRM.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Interfaces
{
    public interface IAddress
    {
        AddressType Type { get; }
    }
}
