using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Abstracts
{
    public abstract class Person : IPerson
    {
        public string Title { get; set; }
        public string FirstNames { get; set; }
        public string LastName { get; set; }
        public Gender? Gender { get; set; }
    }
}
