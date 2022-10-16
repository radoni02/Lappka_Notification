using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions.grpcExceptions
{
    public class UserGrpcNotFoundException : GrpcProjectException
    {
        public UserGrpcNotFoundException(Exception inner = null)
            : base(new Status(statusCode: StatusCode.NotFound, "User not found in notification service database."), "Not found.", inner) { }
    }
}
