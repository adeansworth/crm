using CRM.Data.Classes;
using CRM.Data.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Interfaces
{
    public interface IEntity
    {
        int ID { get; set; }
        DocumentStatus Status { get; set; }
    }
}
