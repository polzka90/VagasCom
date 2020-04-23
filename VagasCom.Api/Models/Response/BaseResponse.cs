using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VagasCom.Api.Models.Response
{
    public class BaseResponse
    {
        public string Message { get; set; }
        public int ErrorNumber { get; set; }
        public object Data { get; set; }
    }
}
