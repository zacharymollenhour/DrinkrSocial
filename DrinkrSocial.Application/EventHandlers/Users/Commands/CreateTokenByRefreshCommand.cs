using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Interfaces.Services;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using DrinkrSocial.Domain.Entities.DTO.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class CreateTokenByRefreshTokenCommand : IRequest<IResponse>
    {
        public string RefreshToken { get; set; }

        public class CreateTokenByRefreshTokenHandler : IRequestHandler<CreateTokenByRefreshTokenCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserRoleRepository _roleRepository;
            private readonly ITokenRefreshRepository _refreshTokenRepository;
            private readonly ITokenService _tokenService;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICacheService _easyCacheService;

            public CreateTokenByRefreshTokenHandler(IUserRepository userRepository, ITokenRefreshRepository refreshTokenRepository, IUnitOfWork unitOfWork, ITokenService tokenService, IUserRoleRepository roleRepository, ICacheService easyCacheService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _tokenService = tokenService;
                _refreshTokenRepository = refreshTokenRepository;
                _roleRepository = roleRepository;
                _easyCacheService = easyCacheService;
            }

            public async Task<IResponse> Handle(CreateTokenByRefreshTokenCommand request, CancellationToken cancellationToken)
            {
                var existRefreshToken = await _refreshTokenRepository.GetAsync(x => x.Code == request.RefreshToken);
                if (existRefreshToken == null)
                {
                    throw new ApiException(404, ResponseMessages.RefreshTokenNotFound);
                }
                var user = await _userRepository.GetByIdAsync(existRefreshToken.UserId);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                if (existRefreshToken.Expiration < DateTime.Now)
                {
                    throw new ApiException(404, ResponseMessages.RefreshTokenExpired);
                }
                var roles = await _roleRepository.GetAllAsync(x => x.UserRoles.Any(y => y.UserId == user.Id));
                List<string> roleNames = new List<string>();
                foreach (var role in roles)
                {
                    roleNames.Add(role.Name);
                }
                var tokendto = _tokenService.CreateToken(user, roleNames);
                existRefreshToken.Code = tokendto.RefreshToken;
                existRefreshToken.Expiration = tokendto.RefreshTokenExpiration;
                await _unitOfWork.SaveChangesAsync();
                await _easyCacheService.RemoveByPrefixAsync("GetAuthenticatedUserWithRoles");
                return new DataResponse<TokenDTO>(tokendto, 200);
            }
        }
    }
}
