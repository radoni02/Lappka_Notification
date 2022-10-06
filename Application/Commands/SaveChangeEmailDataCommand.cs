using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record SaveChangeEmailDataCommand(string Email,string Token,string Id,Guid NotificationId) : ICommand; 
}
