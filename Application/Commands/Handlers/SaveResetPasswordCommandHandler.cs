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
    public class SaveResetPasswordCommandHandler : ICommandHandler<SaveResetPasswordDataCommand>
    {
        private readonly IUserDataRepository _repo;
        private readonly INotificationHistoryRepository _notificationHistoryRepository;

        public SaveResetPasswordCommandHandler(IUserDataRepository repo, INotificationHistoryRepository notificationHistoryRepository)
        {
            _repo = repo;
            _notificationHistoryRepository = notificationHistoryRepository;
        }

        public async Task HandleAsync(SaveResetPasswordDataCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            var user = await _repo.GetUserByEmail(command.Email);
            if(user is null)
            {
                throw new Exception();
            }
            var notification = new NotificationHistory
            {
                Id = command.id,
                Type = Core.Domain.Entities.Consts.NotificationType.RESET_PASSWORD,
                UserEmail = user.Email,
                CreatedAt = DateTime.UtcNow,
                Subject = user.FirstName + " " + user.LastName + " " + user.Username,
                Body = command.token,
            };
            await _notificationHistoryRepository.CreateNotificationHistory(notification);
        }
    }
}
