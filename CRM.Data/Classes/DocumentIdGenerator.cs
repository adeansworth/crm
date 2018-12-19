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
    public class DocumentIdGenerator : IIdGenerator
    {
        public object GenerateId(object container, object document)
        {
            return new DocumentID();
        }

        public bool IsEmpty(object id)
        {
            return id == null;
        }
    }
}
