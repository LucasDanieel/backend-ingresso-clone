using AutoMapper;
using Ingresso.Application.DTOs;
using Ingresso.Domain.Entities;

namespace Ingresso.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<User, UserDTO>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<User, AuthenticatedUserDTO>();
        }
    }
}
