using System;
using MongoDB.Driver;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text;
using ReciveData.Domain.Models;

namespace ReciveData.Repository.MongoDBConnection
{
    public class ConnectionMongoDB
    {
        private readonly IConfiguration configuration;

        public const string DBName = "UserData";

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

        public IMongoCollection<Item> Item
        {
            get { return _BaseDeDados.GetCollection<Item>("Item"); }
        }
    }
}
