using CRM.Shared.Abstracts;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Classes
{
    public class User : UserBase, IEntity
    {
        public string ID { get; set; }
    }
}
