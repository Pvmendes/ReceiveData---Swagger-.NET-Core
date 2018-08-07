using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using ReciveData.Domain.Intefaces.Base;
using ReciveData.Domain.Intefaces.Repositories;
using ReciveData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReciveData.Repository.MySQLConnection
{
    public class ReceiveDataRepository : IReceiveDataRepository, IRepositoryBase<User>
    {
        private IConfiguration _configuracoes;

        public string ConnectionString { get; set; }

        public ReceiveDataRepository(IConfiguration config)
        {
            _configuracoes = config;
            ConnectionString = config.GetConnectionString("DefaultMySQLConnection");
        }

        public async Task<IEnumerable<User>> ListAll()
        {
            using (MySqlConnection conexao = new MySqlConnection(ConnectionString))
            {
                return await conexao.GetAllAsync<User>();
            }
        }

        public async Task SaveUser(User user)
        {
            using (MySqlConnection conexao = new MySqlConnection(ConnectionString))
            {
                await conexao.InsertAsync(user);
            }
        }
    }
}
