using Logs.Model;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logs.DB
{
    public class ConnectionMongoDB
    {
        private readonly IConfiguration configuration;

        public const string DBName = "Logs";
        
        private readonly IMongoClient _client;
        private readonly IMongoDatabase _BaseDeDados;

        public ConnectionMongoDB(IConfiguration config)
        {
            configuration = config;

            _client = new MongoClient(configuration.GetConnectionString("DefaultNoSQLConnection"));
            _BaseDeDados = _client.GetDatabase(DBName);
        }

        public IMongoClient Cliente
        {
            get { return _client; }
        }

        public IMongoCollection<ReceiveDataLogEntitie> ReciveDataLog
        {
            get { return _BaseDeDados.GetCollection<ReceiveDataLogEntitie>("ReciveDataLogs" + DateTime.Now.ToString("yyyy.MM")); }
        }
    }
}
