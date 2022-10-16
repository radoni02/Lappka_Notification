using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.grpcExceptions
{
    public class IdParseException : GrpcProjectException
    {
        public IdParseException(Exception innerException = null) 
            : base(new Status(statusCode: StatusCode.InvalidArgument, "Invalid request data."), "Invalid data.", innerException)
        {
        }
    }
}
