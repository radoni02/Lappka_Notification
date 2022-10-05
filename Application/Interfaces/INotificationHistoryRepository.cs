using Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface INotificationHistoryRepository
    {
        Task CreateNotificationHistory(NotificationHistory obj);
        Task MakAsSend(Guid id);
    }
}
