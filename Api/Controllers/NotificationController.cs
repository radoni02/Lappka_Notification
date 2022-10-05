using Google.Protobuf.WellKnownTypes;
using Grpc.Core;
using Google.Protobuf.WellKnownTypes;
using Convey.CQRS.Commands;
using Microsoft.AspNetCore.Mvc;
using Application.Commands;

namespace Api.Controllers

{
    public class NotificationController : NotificationService.NotificationServiceBase
    {
        private readonly ICommandDispatcher _commandDispatcher;

        public NotificationController(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public override async Task<Empty> ResetPassword(ResetPasswordRequest request,ServerCallContext context)
        {
            var notificationId = Guid.NewGuid();
            var saveDatacommand = new SaveResetPasswordDataCommand(request.Email, request.Token, notificationId);
            await _commandDispatcher.SendAsync(saveDatacommand);

            var sendEmailCommand = new SendResetPasswordEmailCommand(request.Email, request.Token, notificationId);
            await _commandDispatcher.SendAsync(sendEmailCommand);
            return new();
        }
    }
}
