using CRM.Data.Abstracts;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace CRM.Data.Classes
{
    public class IntIdGenerator<T> : IIdGenerator where T : IEntity
    {
        public object GenerateId(object container, object document)
        {
            IMongoCollection<T> collection = (IMongoCollection<T>)container;
            
            if (collection.Find(m => true).Count() > 0)
            {
                var record = collection.AsQueryable().OrderByDescending(m => m.ID).FirstOrDefault();
                
                if (record != null)
                    return record.ID + 1;
            }
            
            return 1;
        }

        public bool IsEmpty(object id)
        {
            return id.Equals(default(int));
        }
    }
}
