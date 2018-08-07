using ReciveData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReciveData.Domain.Intefaces.Repositories
{
    public interface IReceiveDataMongoRepository
    {
        Task SaveAsync(Item item);
    }
}
