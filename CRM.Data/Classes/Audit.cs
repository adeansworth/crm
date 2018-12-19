using CRM.Shared.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Classes
{
    public class Audit
    {
        public Audit()
        {
            Created = LastUpdated = DateTime.Now;
        }

        public DateTime Created { get; private set; }

        [BsonIgnoreIfDefault]
        public IUser CreatedBy { get; set; }

        public DateTime LastUpdated { get; private set; }

        [BsonIgnoreIfDefault]
        public IUser LastUpdatedBy { get; set; }

        public int VersionNumber { get; set; }

        public void Increment()
        {
            LastUpdated = DateTime.Now;
            VersionNumber++;
        }
    }
}
