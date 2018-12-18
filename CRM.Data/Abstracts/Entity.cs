using CRM.Data.Classes;
using CRM.Data.Entities;
using CRM.Data.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Abstracts
{
    public abstract class Entity : IEntity
    {
        public abstract ObjectId ID { get; set; }

        [BsonElement]
        public DocumentStatus Status { get; set; } = new DocumentStatus();

        public override string ToString()
        {
            return ID.ToString();
        }
    }
}
