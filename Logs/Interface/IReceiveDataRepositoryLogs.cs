using Logs.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Interface
{
    public interface IReceiveDataRepositoryLogs
    {
        Task SaveAsync(ReceiveDataLogEntitie log);
    }
}
