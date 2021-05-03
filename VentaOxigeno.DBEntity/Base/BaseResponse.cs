using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DBEntity
{
    public class BaseResponse
    {
        public bool isSuccess { get; set; }
        public string errorCode { get; set; }
        public string errorMessage { get; set; }
        public object data { get; set; }
    }
}
