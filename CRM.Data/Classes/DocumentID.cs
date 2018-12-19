using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Classes
{
    public class DocumentID
    {
        public DocumentID()
        {
            GUID = Guid.NewGuid().ToString();
            Version++;
            LastUpdated = Created = DateTime.Now;
        }

        public int? ID { get; set; }
        public string GUID{ get; set; }
        public long Version { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastUpdated { get; set; }
        public bool Archived { get; set; }
        public bool Deleted { get; set; }
    }
}
