using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record SaveConfirmEmailDataCommand(string Email,string Token,string UserName,string FirstName,string LastName,string UserId,Guid notificationId) : ICommand;
    
}
