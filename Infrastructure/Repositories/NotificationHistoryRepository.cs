using Application.Interfaces;
using Core.Domain.Entities;
using Infrastructure.DataBase;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class NotificationHistoryRepository : INotificationHistoryRepository
    {
        private readonly AppDbContext _contex;

        public NotificationHistoryRepository(AppDbContext contex)
        {
            _contex = contex;
        }

        public async Task CreateNotificationHistory(NotificationHistory obj)
        {
             await _contex.notificationHistories.AddAsync(obj);
            await _contex.SaveChangesAsync();      
        }
        public async Task MakAsSend(Guid id)
        {
            var user = await _contex.notificationHistories.FirstOrDefaultAsync(x => x.Id==id);
            if(user is null)
            {
                //throw new Exception();
            }
            user.IsSend = true;
            await _contex.SaveChangesAsync();   
        }
    }
}
