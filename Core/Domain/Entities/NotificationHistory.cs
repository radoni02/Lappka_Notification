using Core.Domain.Entities.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class NotificationHistory
    {
        public Guid  Id { get; set; }
        public NotificationType Type { get; set; }
        public string UserEmail { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public bool IsSend { get; set; }
        public Guid UserId { get; set; }
    }
}
