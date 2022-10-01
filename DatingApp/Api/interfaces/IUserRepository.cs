using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Entities;

namespace Api.interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);

        Task<bool> saveAllAsync();

        Task<AppUser> GetUsersByIdAsync(int id);
        Task<AppUser> GetUserByUserNameAsync(string username);
        Task<IEnumerable<AppUser>> GetUsersAsync();

        
    }
}