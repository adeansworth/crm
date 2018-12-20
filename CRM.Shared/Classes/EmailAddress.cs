using CRM.Shared.Abstracts;
using CRM.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Classes
{
    public class EmailAddress : InternetAddress
    {
        public override AddressType Type => AddressType.Email;
        public DateTime? Verified { get; set; }
    }
}
