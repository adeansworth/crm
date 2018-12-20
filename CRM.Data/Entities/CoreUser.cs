using CRM.Data.Classes;
using CRM.Data.Interfaces;
using CRM.Shared.Abstracts;
using CRM.Shared.Classes;
using CRM.Shared.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Entities
{
    public class CoreUser : User, IEntity, IAuditable
    {
        [BsonId(IdGenerator = typeof(DocumentIdGenerator))]
        public string ID { get { return base.ID; } set { base.ID = value; } }

        public Audit Audit { get; set; } = new Audit();
    }
}
