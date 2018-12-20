using CRM.Data.Abstracts;
using CRM.Data.Classes;
using CRM.Data.Interfaces;
using CRM.Extensions;
using CRM.Shared.Abstracts;
using CRM.Shared.Enums;
using CRM.Shared.Interfaces;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Entities
{
    public class ProjectInstallation : InstallationBase, IEntity, IAuditable
    {
        [BsonId(IdGenerator = typeof(DocumentIdGenerator))]
        public string ID { get; set; }

        public bool DefaultProject { get; set; } = true;
        public Audit Audit { get; set; } = new Audit();
    }
}
