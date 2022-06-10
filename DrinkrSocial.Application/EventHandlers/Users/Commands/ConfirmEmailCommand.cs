using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Interfaces.Repositories;
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
    public class ConfirmEmailCommand : IRequest<IResponse>
    {
        public string EmailConfirmationCode { get; set; }

        public ConfirmEmailCommand(string code)
        {
            EmailConfirmationCode = code;
        }
        public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;

            public ConfirmEmailCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
            }

            public async Task<IResponse> Handle(ConfirmEmailCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(x => x.EmailConfirmationCode == request.EmailConfirmationCode || x.EmailConfirmedCode == request.EmailConfirmationCode);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                if (user.EmailConfirmed)
                {
                    throw new ApiException(400, ResponseMessages.AlreadyEmailConfirmed);
                }
                user.EmailConfirmed = true;
                user.EmailConfirmationCode = null;
                user.EmailConfirmedCode = request.EmailConfirmationCode;
                await _unitOfWork.SaveChangesAsync();
                return new SuccessResponse(200, ResponseMessages.SuccessfullyEmailConfirmed);
            }
        }
    }
}
