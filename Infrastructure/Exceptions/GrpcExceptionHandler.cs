using Application.Exceptions;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Infrastructure.Exceptions
{
    public class GrpcExceptionHandler : Interceptor
    {
        private readonly ILogger<GrpcExceptionHandler> _logger;

        public GrpcExceptionHandler(ILogger<GrpcExceptionHandler> logger)
        {
            _logger = logger;
        }
        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(
        TRequest request,
        ServerCallContext context,
        UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                return await continuation.Invoke(request, context);
            }
            catch (Exception ex)
            {
                return MapResponse<TRequest, TResponse>(context, ex);
            }
        }
        private TResponse MapResponse<TRequest, TResponse>(ServerCallContext context, Exception ex)
        {
            var concreteResponse = Activator.CreateInstance<TResponse>();

            if (ex is GrpcProjectException de)
            {
                context.Status = de.Status;
            }
            else
            {
                context.Status = new Status(StatusCode.Internal, "Internal server error");
            }

            return concreteResponse;
        }

    }
}
