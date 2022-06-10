using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Helpers;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Interfaces.Services;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class ResetPasswordCommand : IRequest<IResponse>
    {
        public string ResetPasswordCode { get; set; }
        public string Email { get; set; }

        public ResetPasswordCommand(string code, string email)
        {
            ResetPasswordCode = code;
            Email = email;
        }

        public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEmailService _emailService;

            public ResetPasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IEmailService emailService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _emailService = emailService;
            }

            public async Task<IResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(x => x.Email == request.Email);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                var controlcode = await _userRepository.GetAsync(x => x.ResetPasswordCode == request.ResetPasswordCode);
                if (controlcode == null)
                {
                    throw new ApiException(400, ResponseMessages.ResetPasswordCodeInvalid);
                }

                var newPassword = AuthenticationHelper.GenerateRandomString(8);
                var (passwordHash, passwordSalt) = AuthenticationHelper.CreateHash(newPassword);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.ResetPasswordCode = null;
                await _unitOfWork.SaveChangesAsync();
                await _emailService.SendNewPasswordAsync(newPassword, user.Email);
                return new SuccessResponse(200, ResponseMessages.PasswordSuccessfullyReset);
            }
        }
    }
}
