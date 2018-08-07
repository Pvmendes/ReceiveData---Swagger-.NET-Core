using Logs.Repository.Inferface;
using Microsoft.Extensions.Configuration;
using System;
using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using Logs.Model;
using Logs.Interface;
using MongoDB.Driver;
using Logs.DB;

namespace Logs.Repository
{
    public class ReceiveDataRepositoryLogs : IReceiveDataRepositoryLogs, IRepository
    {
        private readonly IConfiguration configuration;



        public ReceiveDataRepositoryLogs(IConfiguration config)
        {
            configuration = config;
        }

        public async Task SaveAsync(ReceiveDataLogEntitie log)
        {
            await SaveMongoDB(log);
        }
               
        private async Task SaveMongoDB(ReceiveDataLogEntitie log)
        {
            var conexaoBiblioteca = new ConnectionMongoDB(configuration);

            await conexaoBiblioteca.ReciveDataLog.InsertOneAsync(log);
        }
    }
}
