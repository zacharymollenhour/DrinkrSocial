using DrinkrSocial.Application.Interfaces;
using DrinkrSocial.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.Features.UserFeatures.Queries
{
    public class UserLoginQuery : IRequest<User>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

        public class UserLoginQueryHandler : IRequestHandler<UserLoginQuery, User>
        {
            private readonly IApplicationDbContext _context;

            public UserLoginQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<User> Handle(UserLoginQuery query, CancellationToken cancellationToken)
            {
                var user = _context.Users.FirstOrDefault(x => x.UserName == query.UserName && x.Password == query.Password);
                if (user == null)
                    return null;
                return user;
            }

        }
    }
}
