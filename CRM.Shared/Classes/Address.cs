using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Classes
{
    public class Address : IAddress
    {
        public AddressType Type => AddressType.MailingAddress;
        public string BuildingName { get; set; }
        public string RoadName { get; set; }
        public string Locality { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public Coordinates Coordinates { get; set; }
    }
}
