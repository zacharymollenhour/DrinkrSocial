using AutoMapper;
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
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class UpdateUserCommand : IRequest<IResponse>
    {
        [JsonIgnore]
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;
            private readonly ICacheService _easyCacheService;

            public UpdateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IMapper mapper, ICacheService easyCacheService)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _easyCacheService = easyCacheService;
            }

            public async Task<IResponse> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetByIdAsync(request.UserId);
                if (user == null)
                {
                    throw new ApiException(404, ResponseMessages.UserNotFound);
                }
                var username = await _userRepository.GetAsync(x => x.UserName == request.UserName);
                if (username != null && user.UserName != request.UserName)
                {
                    throw new ApiException(400, ResponseMessages.UsernameAlreadyExists);
                }
                _mapper.Map(request, user);
                await _unitOfWork.SaveChangesAsync();
                await _easyCacheService.RemoveByPrefixAsync("GetAuthenticatedUserWithRoles");
                return new SuccessResponse(200, ResponseMessages.UpdatedSuccessfully);
            }
        }
    }
}
