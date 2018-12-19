using CRM.Data.Entities;
using CRM.Shared.Abstracts;
using CRM.Shared.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRM.Data.Interfaces
{
    public interface IDataContext
    {
        IMongoQueryable<T> GetQueryable<T>(string collectionName);
        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}
