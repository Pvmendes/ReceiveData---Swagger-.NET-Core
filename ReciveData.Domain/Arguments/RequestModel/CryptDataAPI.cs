using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReciveData.RequestModel
{
    public class CryptDataAPI
    {
        private string _data;

        public string Data
        { 
            get
            {
                //return _data.Replace(" ", "+");
                return _data;
            }
            set
            {
                _data = value;
            }
        }
    }
}
