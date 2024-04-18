using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coreLayer
{
    public class OperationResult
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public OperationResult(int statusCode, string message, object data = null)
        {
            StatusCode = statusCode;
            Message = message;
            Data = data;
        }

    }

    public enum OperationStatus
    {
        Success = 200,
        Failure = 404
        
    }
    
    
}
