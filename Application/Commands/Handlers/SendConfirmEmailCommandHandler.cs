using Application.Interfaces;
using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public record SendConfirmEmailCommandHandler : ICommandHandler<SendConfirmEmailCommand>
    {
        private readonly INotificationHistoryRepository _notificationHistoryRepository;

        public SendConfirmEmailCommandHandler(INotificationHistoryRepository notificationHistoryRepository)
        {
            _notificationHistoryRepository = notificationHistoryRepository;
        }

        public async Task HandleAsync(SendConfirmEmailCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            Console.WriteLine($"Potwierdzenie maila {command.Email}, tokenem: {command.Token}");
            await _notificationHistoryRepository.MakAsSend(command.NotificationId);
        }
    }
}
