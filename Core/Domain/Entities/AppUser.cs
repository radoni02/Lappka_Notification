using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Entities
{
    public class AppUser
    {
        public AppUser(Guid id, string username, string email, string firstName, string lastName)
        {
            Id = id;
            Username = username;
            Email = email;
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; init; }
        public string Username { get; init; }
        public string Email { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
    }
}
