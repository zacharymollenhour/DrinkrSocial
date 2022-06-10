using AutoMapper;
using DrinkrSocial.Application.Constants;
using DrinkrSocial.Application.ExceptionHandler;
using DrinkrSocial.Application.Helpers;
using DrinkrSocial.Application.Interfaces.Repositories;
using DrinkrSocial.Application.Interfaces.Services;
using DrinkrSocial.Application.Wrappers.Abstract;
using DrinkrSocial.Application.Wrappers.Concrete;
using DrinkrSocial.Domain.Entities.Models.Users;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EventHandlers.Users.Commands
{
    public class UserRegistrationCommand : IRequest<IResponse>
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        

        public class RegisterCommandHandler : IRequestHandler<UserRegistrationCommand, IResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUnitOfWork _unitOfWork;
            private readonly IEmailService _emailService;
            private readonly IMapper _mapper;

            public RegisterCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork, IEmailService emailService, IMapper mapper)
            {
                _userRepository = userRepository;
                _unitOfWork = unitOfWork;
                _emailService = emailService;
                _mapper = mapper;
            }
            
            public async Task<IResponse> Handle(UserRegistrationCommand request, CancellationToken cancellationToken)
            {
                var existingUser = await _userRepository.GetAsync(x => x.UserName == request.UserName || x.Email == request.Email, noTracking: true);

                if (existingUser?.UserName == request.UserName)
                    throw new ApiException(400, ResponseMessages.UsernameAlreadyExists);

                if (existingUser?.Email == request.Email)
                    throw new ApiException(400, ResponseMessages.EmailIsAlreadyExist);

                var (passwordHash, passwordSalt) = AuthenticationHelper.CreateHash(request.Password);
                var user = _mapper.Map<User>(request);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;
                user.EmailConfirmationCode = AuthenticationHelper.GenerateRandomString(20);
                await _userRepository.AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
                //string link = "http://localhost:8080/confirmemail/" + user.EmailConfirmationCode; if u use spa you must use this link example
                string link = "http://localhost:5010/api/users/confirmemail/" + user.EmailConfirmationCode;
                await _emailService.ConfirmationMailAsync(link, request.Email);
                return new SuccessResponse(200, ResponseMessages.RegisterSuccessfully);
            }
        }
    }
}
