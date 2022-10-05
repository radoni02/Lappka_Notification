using Application.Interfaces;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class SendResetPasswordCommandHandler : ICommandHandler<SendResetPasswordEmailCommand>
    {
        private readonly IUserDataRepository _repo;
        private readonly INotificationHistoryRepository _notificationHistoryRepository;

        public SendResetPasswordCommandHandler(IUserDataRepository repo, INotificationHistoryRepository notificationHistoryRepository)
        {
            _repo = repo;
            _notificationHistoryRepository = notificationHistoryRepository;
        }

        public async Task HandleAsync(SendResetPasswordEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine($"Reset hasła dla emaila {command.Email}, token:{command.Token}");

            await _notificationHistoryRepository.MakAsSend(command.Id);
        }
    }
}
