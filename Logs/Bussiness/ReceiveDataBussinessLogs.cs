using Logs.Bussiness.Interface;
using Logs.Interface;
using Logs.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Bussiness
{
    public class ReceiveDataBussinessLogs : IReceiveDataBussinessLogs, IBussiness
    {
        private readonly IReceiveDataRepositoryLogs _reciveDataRepositoryLogs;

        public ReceiveDataBussinessLogs(IReceiveDataRepositoryLogs reciveDataRepositoryLogs)
        {
            this._reciveDataRepositoryLogs = reciveDataRepositoryLogs;
        }

        public async Task Save(ReceiveDataLogEntitie log)
        {
            await _reciveDataRepositoryLogs.SaveAsync(log);
        }
    }
}
