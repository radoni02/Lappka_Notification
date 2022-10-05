using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands
{
    public record SendResetPasswordEmailCommand(string Email, string Token, Guid Id) : ICommand;
    
    
}
