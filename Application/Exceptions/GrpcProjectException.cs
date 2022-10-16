using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class GrpcProjectException : RpcException
    {
        public Exception ProjectInnerException { get; }
        public GrpcProjectException(Status status,string message,Exception innerException = null) : base(status, message)
        {
            ProjectInnerException = innerException;
        }
    }
}
