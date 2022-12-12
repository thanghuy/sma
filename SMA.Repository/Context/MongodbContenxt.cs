using MongoDB.Driver;
using SMA.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMA.Repository.Context
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }
    }

    public class MongoContext : IMongoContext
    {
        public MongoContext(IMongoDbSettings connectionSetting)
        {
            var client = new MongoClient(connectionSetting.ConnectionString);
            Database = client.GetDatabase(connectionSetting.DatabaseName);
        }

        public IMongoDatabase Database { get; }
    }
}
