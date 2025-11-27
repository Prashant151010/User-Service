using MediatR;
using User.Domain.DTOs;
using User.Domain.Models;

namespace User.Application.Services.Auth.Commands
{
    public class TokenCommand : IRequest<ApiResponse<TokenDtoResponse>>
    {
        public TokenDto TokenDto { get; }

        public TokenCommand(TokenDto dto)
        {
            TokenDto = dto;
        }
    }
}
