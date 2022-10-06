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
    public class SaveChangeEmailDataCommandHandler : ICommandHandler<SaveChangeEmailDataCommand>
    {
        private readonly IUserDataRepository _repo;
        private readonly INotificationHistoryRepository _notificationHistoryRepository;

        public SaveChangeEmailDataCommandHandler(IUserDataRepository repo, INotificationHistoryRepository notificationHistoryRepository)
        {
            _repo = repo;
            _notificationHistoryRepository = notificationHistoryRepository;
        }

        public async Task HandleAsync(SaveChangeEmailDataCommand command, CancellationToken cancellationToken = new CancellationToken())
        {
            if(!Guid.TryParse(command.Id,out var UserId))
            {
                throw new Exception();
            }
            var user = await _repo.GetUserById(UserId);
            if(user is null)
            {
                throw new Exception();
            }
            var notification = new NotificationHistory() 
            {
                Id=command.NotificationId,
                Type=Core.Domain.Entities.Consts.NotificationType.CHANGE_EMAIL,
                UserEmail=command.Email,
                Subject=user.FirstName + " " + user.LastName + " " + user.Username,
                Body=command.Token,
                UserId=UserId
            };
            await _notificationHistoryRepository.CreateNotificationHistory(notification);
        }
    }
}
