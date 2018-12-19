using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Classes
{
    public class EntityWrapper<T>
    {
        [BsonId(IdGenerator = typeof(DocumentIdGenerator))]
        public string ID { get; set; }
        public T Document { get; set; }
    }
}
