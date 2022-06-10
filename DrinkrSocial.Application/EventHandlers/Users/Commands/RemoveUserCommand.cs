using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
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
    public class RemoveUserCommand : IRequest<IResponse>
    {
        public Guid UserId { get; set; }

        public RemoveUserCommand(Guid userid)
        {
            UserId = userid;
        }

        public class RemoveUserCommandHandler : IRequestHandler<RemoveUserCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICacheService _easyCacheService;

            public RemoveUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ICacheService easyCacheService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _easyCacheService = easyCacheService;
            }

            public async Task<IResponse> Handle(RemoveUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                _userRepository.Remove(user);
                await _unitOfWork.SaveChangesAsync();
                await _easyCacheService.RemoveByPrefixAsync("GetAuthenticatedUserWithRoles");
                return new SuccessResponse(200, ResponseMessages.DeletedSuccessfully);
            }
        }
    }
}
