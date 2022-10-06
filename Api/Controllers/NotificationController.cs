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

        public override async Task<Empty> ChangeEmail(ChangeEmailRequest request,ServerCallContext context)
        {
            var notificationId = Guid.NewGuid();
            var saveDataCommand = new SaveChangeEmailDataCommand(request.Email, request.Token, request.UserId, notificationId);
            await _commandDispatcher.SendAsync(saveDataCommand);

            var sendDataCommand = new SendChangeEmailCommand(request.Email, request.Token, notificationId);
            await _commandDispatcher.SendAsync(sendDataCommand);
            return new();
        }

        public override async Task<Empty> ConfirmEmail(ConfirmEmailRequest request,ServerCallContext context)
        {
            var notificationId = Guid.NewGuid();
            var saveDataCommand = new SaveConfirmEmailDataCommand(request.Email, request.Token,
                request.Username, request.Firstname, request.Lastname, request.Userid,notificationId);
            await _commandDispatcher.SendAsync(saveDataCommand);

            var sendDataCommand = new SendConfirmEmailCommand(request.Email, request.Token, notificationId);
            await _commandDispatcher.SendAsync(sendDataCommand);
            return new();
        }
    }
}
