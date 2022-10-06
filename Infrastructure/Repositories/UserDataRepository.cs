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
    public class UserDataRepository : IUserDataRepository
    {
        private readonly AppDbContext _context;

        public UserDataRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<AppUser> GetUserByEmail(string email)
        {
            return await _context.appUsers.FirstOrDefaultAsync(x => x.Email==email);
        }

        public async Task<AppUser> GetUserById(Guid id)
        {
            return await _context.appUsers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateUserData(AppUser obj)
        {
            await _context.appUsers.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

    }
}
