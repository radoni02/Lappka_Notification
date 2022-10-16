using Application.Exceptions.grpcExceptions;
using Application.Interfaces;
using Convey.CQRS.Commands;
using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Handlers
{
    public class SaveConfirmEmailDataCommandHandler : ICommandHandler<SaveConfirmEmailDataCommand>
    {
        private readonly IUserDataRepository _repo;
        private readonly INotificationHistoryRepository _notificationHistoryRepository;

        public SaveConfirmEmailDataCommandHandler(IUserDataRepository repo, INotificationHistoryRepository notificationHistoryRepository)
        {
            _repo = repo;
            _notificationHistoryRepository = notificationHistoryRepository;
        }

        public async Task HandleAsync(SaveConfirmEmailDataCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            if(!Guid.TryParse(command.UserId,out var userId))
            {
                throw new IdParseException();
            }
            var user = new AppUser(userId, command.UserName, command.Email, command.FirstName, command.LastName);
            await _repo.CreateUserData(user);
            var notification = new NotificationHistory()
            {
                Id = command.notificationId,
                Type = Core.Domain.Entities.Consts.NotificationType.EMAIL_CONFIRM,
                UserEmail = command.Email,
                Subject = command.FirstName + " " + command.LastName,
                Body = command.Token,
                UserId = userId
            };
            await _notificationHistoryRepository.CreateNotificationHistory(notification);
        }
    }
}
