using CRM.Data.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Interfaces
{
    public interface IAuditable : IEntity
    {
        Audit Audit { get; set; }
    }
}
