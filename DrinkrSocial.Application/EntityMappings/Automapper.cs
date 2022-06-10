using AutoMapper;
using DrinkrSocial.Application.EventHandlers.Users.Commands;
using DrinkrSocial.Domain.Entities.DTO;
using DrinkrSocial.Domain.Entities.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinkrSocial.Application.EntityMappings
{
    public class Automapper : Profile
    {
        public Automapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<User, UserRegistrationCommand>().ReverseMap();
        }
    }
}
