using Application.Interfaces;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class SendChangeEmailCommandHandler : ICommandHandler<SendChangeEmailCommand>
    {
        private readonly INotificationHistoryRepository _notificationHistoryRepository;

        public SendChangeEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository)
        {
            _notificationHistoryRepository = notificationHistoryRepository;
        }

        public async Task HandleAsync(SendChangeEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine($"Reset maila {command.Email}, token: {command.Token}");

            await _notificationHistoryRepository.MakAsSend(command.Id);
        }
    }
}
