using CRM.Shared.Classes;
using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Abstracts
{
    public abstract class PersonBase : IPerson
    {
        public string Title { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
        public IEnumerable<Address> Addresses { get; set; }
    }
}
