using System;
using System.Collections.Generic;
using System.Text;

namespace Logs.Model
{
    public class LogEntitie
    {
        public DateTime Data { get; set; }        
        public string Exception { get; set; }
        public string MethodName { get; set; }
    }
}
