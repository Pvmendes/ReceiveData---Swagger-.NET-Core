using Microsoft.Extensions.Configuration;
using ReciveData.Domain.Intefaces.Base;
using ReciveData.Domain.Intefaces.Repositories;
using ReciveData.Domain.Models;
using ReciveData.Repository.MongoDBConnection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReciveData.Repository.MongoDB
{
    public class ReceiveDataMongoRepository : IReceiveDataMongoRepository, IRepositoryBase<Item>
    {
        private readonly IConfiguration configuration;

        public ReceiveDataMongoRepository(IConfiguration config)
        {
            configuration = config;
        }

        public async Task SaveAsync(Item item)
        {
            var conexaoBiblioteca = new ConnectionMongoDB(configuration);

            await conexaoBiblioteca.Item.InsertOneAsync(item);
        }

        //public async Task<IEnumerable<Item>> GetAll()
        //{
        //    var conexaoBiblioteca = new ConnectionMongoDB(configuration);
        //    return await conexaoBiblioteca.Item.;
        //}
    }
}
