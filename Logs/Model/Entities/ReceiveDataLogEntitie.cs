using System;
using System.Collections.Generic;
using System.Text;

namespace Logs.Model
{
    public class ReceiveDataLogEntitie : LogEntitie
    {
        public int IdClient { get; set; }
        public string Json { get; set; }
    }
}
