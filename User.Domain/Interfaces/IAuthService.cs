using User.Domain.DTOs;
using User.Domain.Models;

namespace User.Domain.Interfaces
{
    public interface IAuthService
    {
        Task<ApiResponse<TokenDtoResponse>> AuthenticateAsync(TokenDto dto);
    }
}
