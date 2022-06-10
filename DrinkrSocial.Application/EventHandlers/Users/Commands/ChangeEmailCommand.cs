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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class ChangeEmailCommand : IRequest<IResponse>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }

        public string Email { get; set; }

        public ChangeEmailCommand(Guid userid, string email)
        {
            UserId = userid;
            Email = email;
        }

        public class ChangeEmailCommandHandler : IRequestHandler<ChangeEmailCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEmailService _emailService;
            private readonly ICacheService _easyCacheService;

            public ChangeEmailCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IEmailService emailService, ICacheService easyCacheService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _emailService = emailService;
                _easyCacheService = easyCacheService;
            }

            public async Task<IResponse> Handle(ChangeEmailCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                var email = await _userRepository.GetAsync(x => x.Email == request.Email);
                if (email != null && user.Email != request.Email)
                {
                    throw new ApiException(400, ResponseMessages.EmailIsAlreadyExist);
                }
                user.Email = request.Email;
                user.EmailConfirmed = false;
                user.EmailConfirmedCode = null;
                user.EmailConfirmationCode = AuthenticationHelper.GenerateRandomString(20);
                await _unitOfWork.SaveChangesAsync();
                string link = "http://localhost:5010/api/users/confirmemail/" + user.EmailConfirmationCode;
                await _emailService.ConfirmationMailAsync(link, request.Email);
                await _easyCacheService.RemoveByPrefixAsync("GetAuthenticatedUserWithRoles");
                return new SuccessResponse(200, ResponseMessages.EmailSuccessfullyChangedConfirmYourEmail);
            }
        }
    }
}
