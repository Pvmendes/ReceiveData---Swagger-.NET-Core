using ReciveData.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ReciveData.Domain.Intefaces.Service
{
    public interface IReceiveDataService
    {
        Task<IEnumerable<User>> SaveUser(User user);
        Task SaveItem(IEnumerable<Item> itensList);
    }
}
