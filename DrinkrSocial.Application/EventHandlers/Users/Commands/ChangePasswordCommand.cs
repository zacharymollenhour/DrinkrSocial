using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Helpers;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class ChangePasswordCommand : IRequest<IResponse>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }


        public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;

            public ChangePasswordCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                if (request.NewPassword != request.ConfirmPassword)
                {
                    throw new ApiException(400, ResponseMessages.PasswordDontMatchWithConfirmation);
                }
                if (!AuthenticationHelper.VerifyHash(request.CurrentPassword, user.PasswordHash, user.PasswordSalt))
                {
                    throw new ApiException(400, ResponseMessages.CurrentPasswordIsFalse);
                }

                var (passwordHash, passwordSalt) = AuthenticationHelper.CreateHash(request.NewPassword);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                await _unitOfWork.SaveChangesAsync();
                return new SuccessResponse(200, ResponseMessages.PasswordChangedSuccessfully);
            }
        }
    }
}
