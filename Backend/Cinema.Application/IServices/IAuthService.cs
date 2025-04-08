using Cinema.Application.DTOs;
using Cinema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Application.IServices
{
    public interface IAuthService
    {
        Task<User?> RegisterAsync(UserDTO request);
        Task<TokenResponseDTO?> LoginAsync(LoginUserDTO request);
        Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request);
    }
}
