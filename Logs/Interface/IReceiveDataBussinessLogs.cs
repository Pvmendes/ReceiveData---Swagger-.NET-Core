using Logs.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logs.Interface
{
    public interface IReceiveDataBussinessLogs
    {
        Task Save(ReceiveDataLogEntitie log);
    }
}
