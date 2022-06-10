using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Helpers;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Interfaces.Services;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using DrinkrSocial.Domain.Entities.DTO.Users;
using DrinkrSocial.Domain.Entities.Models;
using DrinkrSocial.Domain.Entities.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class LoginCommand : IRequest<IResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserRoleRepository _roleRepository;
            private readonly ITokenService _tokenService;
            private readonly ITokenRefreshRepository _tokenRefreshRepository;
            private readonly IUnitOfWork _unitOfWork;

            public LoginCommandHandler(IUserRepository userRepository, IUserRoleRepository  userRoleRepository, IUnitOfWork unitOfWorkRepository, ITokenService tokenService, ITokenRefreshRepository tokenRefreshRepostiory)
            {
                _userRepository = userRepository;
                _roleRepository = userRoleRepository;
                _unitOfWork = unitOfWorkRepository;
                _tokenService = tokenService;
                _tokenRefreshRepository = tokenRefreshRepostiory;
            }

            public async Task<IResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                var userFromDB = await _userRepository.GetAsync(x => x.UserName == request.UserName, noTracking: true);

                if (userFromDB == null)
                    throw new ApiException(404, ResponseMessages.UserNotFound);

                if (!userFromDB.EmailConfirmed)
                    throw new ApiException(400, ResponseMessages.EmailConfirmationRequired);

                // Attempt to validate password
                if (!AuthenticationHelper.VerifyHash(request.Password, userFromDB.PasswordHash, userFromDB.PasswordSalt))
                    throw new ApiException(400, ResponseMessages.AuthenticationFailed);

                // Get the User roles
                var userRoles = await _roleRepository.GetAllAsync(x => x.UserRoles.Any(z => z.UserId == userFromDB.Id));
                List<string> userRoleNames = new List<string>();

                // Loop through the user roles and extract the user roles names
                foreach (var userRole in userRoles)
                {
                    userRoleNames.Add(userRole.Name);
                }

                // Handle the Toekn Logic For Refreshing a Token
                var tokenDTO = _tokenService.CreateToken(userFromDB, userRoleNames);
                var refreshToken = await _tokenRefreshRepository.GetAsync(x => x.UserId == userFromDB.Id);

                if (refreshToken == null)
                {
                    await _tokenRefreshRepository.AddAsync(new TokenRefresh { UserId = userFromDB.Id, Code = tokenDTO.RefreshToken, Expiration = tokenDTO.RefreshTokenExpiration });
                    await _unitOfWork.SaveChangesAsync();
                }

                else
                {
                    refreshToken.Code = tokenDTO.RefreshToken;
                    refreshToken.Expiration = tokenDTO.RefreshTokenExpiration;
                    await _unitOfWork.SaveChangesAsync();
                }

                return new DataResponse<TokenDTO>(tokenDTO, 200);
            }
        }
    }
}
