using ReciveData.Domain.Intefaces.Base;
using ReciveData.Domain.Intefaces.Service;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ReciveData.Domain.Models;
using ReciveData.Domain.Intefaces.Repositories;

namespace ReciveData.Domain.Service
{
    public class ReceiveDataService: IReceiveDataService, IServiceBase
    {
        private readonly IReceiveDataRepository reciveDataRepository;
        private readonly IReceiveDataMongoRepository receiveDataMongoRepository;

        public ReceiveDataService(
            IReceiveDataRepository reciveData
            ,IReceiveDataMongoRepository receiveDataMongoRepository)
        {
            reciveDataRepository = reciveData;
            this.receiveDataMongoRepository = receiveDataMongoRepository;
        }

        public async Task<IEnumerable<User>> SaveUser(User user)
        {
            await reciveDataRepository.SaveUser(user);

            return await reciveDataRepository.ListAll();
        }

        public async Task SaveItem(IEnumerable<Item> itensList)
        {
            foreach (var item in itensList)
            {
                await receiveDataMongoRepository.SaveAsync(item);
            }            
        }
    }
}
