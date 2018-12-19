using CRM.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Interfaces
{
    public interface IPerson
    {
        string Title { get; set; }
        string FirstNames { get; set; }
        string LastName { get; set; }
        Gender? Gender { get; set; }
    }
}
