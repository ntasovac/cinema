using Cinema.Application.DTOs;
using Cinema.Application.IServices;
using Cinema.Domain.Entities;
using Cinema.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Application.Services
{
    public class AuthService : IAuthService
    {
        private IAuthRepository _authRepository;
        public AuthService(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public async Task<TokenResponseDTO?> LoginAsync(LoginUserDTO request)
        {
            var result = await _authRepository.LoginAsync(request.Email, request.Password);
            if (result is null)
                return null;

            return new TokenResponseDTO
            {
                AccessToken = result.Value.Item1,
                RefreshToken = result.Value.Item2
            };
        }

        public async Task<TokenResponseDTO?> RefreshTokensAsync(RefreshTokenRequestDTO request)
        {
            var result = await _authRepository.RefreshTokensAsync(request.UserId, request.RefreshToken);
            if (result is null)
                return null;

            return new TokenResponseDTO
            {
                AccessToken = result.Value.Item1,
                RefreshToken = result.Value.Item2
            };
        }

        public async Task<User?> RegisterAsync(UserDTO request)
        {
            var user = new User();
            var hashedPassword = new PasswordHasher<User>()
                .HashPassword(user, request.Password);
            user.Email = request.Email;
            user.PasswordHash = hashedPassword;
            user.FirstName = request.FirstName;
            user.LastName = request.LastName;
            user.PhoneNumber = request.PhoneNumber;
            user.BirthDate = request.BirthDate;

            return await _authRepository.RegisterAsync(user);
        }
    }
}
