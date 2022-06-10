using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Interfaces.Services;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using DrinkrSocial.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class UpdateUserRoleCommand : IRequest<IResponse>
    {
        public Guid UserId { get; set; }
        public Guid[] RoleIds { get; set; }


        public class UpdateUserRoleCommandHandler : IRequestHandler<UpdateUserRoleCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly ICacheService _easyCacheService;

            public UpdateUserRoleCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, ICacheService easyCacheService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _easyCacheService = easyCacheService;
            }

            public async Task<IResponse> Handle(UpdateUserRoleCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetUserRolesByUserIdAsync(request.UserId);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                user.UserRoles = request.RoleIds.Select(roleid => new UserRole
                {
                    RoleId = roleid
                }).ToList();
                await _unitOfWork.SaveChangesAsync();
                await _easyCacheService.RemoveByPrefixAsync("GetAuthenticatedUserWithRoles");
                return new SuccessResponse(200, ResponseMessages.UserRolesUpdatedSuccessfully);
            }
        }
    }
}
