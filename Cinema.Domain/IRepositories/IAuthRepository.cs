using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Domain.IRepositories
{
    public interface IAuthRepository
    {
        Task<User?> RegisterAsync(User request);
        Task<(string, string)?> LoginAsync(string email, string password);
        Task<(string, string)?> RefreshTokensAsync(int userId , string refreshToken);
    }
}
