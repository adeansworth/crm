using CRM.Data.Classes;
using CRM.Data.Interfaces;
using CRM.Shared.Abstracts;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Entities
{
    public class CoreUser : User, IEntity, IAuditable
    {
        [BsonId(IdGenerator = typeof(DocumentIdGenerator))]
        public string ID { get; set; }

        public Audit Audit { get; set; } = new Audit();
    }
}
