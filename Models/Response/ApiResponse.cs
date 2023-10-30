using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RedeSocialAPI.src.Base.Utils;

namespace RedeSocialAPI.Models.Response
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public EnResultCode Code { get; set; }
        public string Message { get; set; }
        public int ResultCount { get; set; }
    }
    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }
}