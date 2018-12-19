using CRM.Data.Classes;
using CRM.Data.Interfaces;
using CRM.Shared.Abstracts;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Entities
{
    public class CoreUser : User, IEntity, IAuditable<CoreUser>
    {
        [BsonId(IdGenerator = typeof(DocumentIdGenerator))]
        public DocumentID ID { get; set; }
    }
}
