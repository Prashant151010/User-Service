using MediatR;
using User.Application.Services.Auth.Commands;
using User.Domain.DTOs;
using User.Domain.Interfaces;
using User.Domain.Models;

namespace User.Application.Services.Auth.Handlers
{
    public class TokenCommandHandler(IAuthService authService) : IRequestHandler<TokenCommand, ApiResponse<TokenDtoResponse>>
    {
        private readonly IAuthService _authService = authService;

        public async Task<ApiResponse<TokenDtoResponse>> Handle(TokenCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<TokenDtoResponse>();

            // Validate command object
            if (request == null)
            {
                response.Status = "error";
                response.Message = "Invalid request.";
                return response;
            }

            // Validate DTO
            if (request.TokenDto == null)
            {
                response.Status = "error";
                response.Message = "Login data cannot be null.";
                return response;
            }

            // Validate username
            if (string.IsNullOrWhiteSpace(request.TokenDto.User))
            {
                response.Status = "error";
                response.Message = "Username is required.";
                return response;
            }

            // Validate password
            if (string.IsNullOrWhiteSpace(request.TokenDto.Password))
            {
                response.Status = "error";
                response.Message = "Password is required.";
                return response;
            }

            // Call authentication service
            var authResponse = await _authService.AuthenticateAsync(request.TokenDto);

            if (authResponse == null)
            {
                response.Status = "error";
                response.Message = "Authentication failed.";
                return response;
            }

            return authResponse;
        }
    }
}
