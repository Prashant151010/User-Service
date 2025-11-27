using AutoMapper;
using Microsoft.Extensions.Logging;
using User.Domain.DTOs;
using User.Domain.Interfaces;
using User.Domain.IRepositories;
using User.Domain.Models;

namespace User.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IRepository _repository;
        private readonly ILogger<AuthService> _logger;
        private readonly IMapper _mapper;
        public AuthService(IRepository repository, ILogger<AuthService> logger, IMapper mapper)
        {

        }

        public Task<ApiResponse<TokenDtoResponse>> AuthenticateAsync(TokenDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
