using ReciveData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReciveData.Domain.Models;

namespace ReciveData.Domain.Intefaces.Repositories
{
    public interface IReceiveDataRepository
    {
        Task<IEnumerable<User>> ListAll();
        Task SaveUser(User user);
    }
}
