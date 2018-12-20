using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Shared.Classes
{
    public class Coordinates : IAddress
    {
        public AddressType Type => AddressType.Coordinates;
        public float Latitude { get; set; }
        public float Longitude { get; set; }
    }
}
