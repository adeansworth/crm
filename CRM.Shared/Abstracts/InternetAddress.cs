using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Abstracts
{
    public abstract class InternetAddress : IInternetAddress
    {
        public abstract AddressType Type { get; }
        public string Data { get; set; }
    }
}
