using AutoMapper;
using Ingresso.Application.DTOs.CinemaDTOs;
using Ingresso.Application.DTOs.CinemaRoomDTOs;
using Ingresso.Application.DTOs.CityDTOs;
using Ingresso.Application.DTOs.MovieDescriptionDTOs;
using Ingresso.Application.DTOs.MovieDTOs;
using Ingresso.Application.DTOs.SessionDTOs;
using Ingresso.Application.DTOs.UserDTOs;
using Ingresso.Domain.Entities;

namespace Ingresso.Application.Mappings
{
    public class DomainToDtoMapping : Profile
    {
        public DomainToDtoMapping()
        {
            CreateMap<User, UserDTO>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<User, AuthenticatedUserDTO>();
            CreateMap<City, CityDTO>();
            CreateMap<Cinema, CinemaDTO>()
                .ForMember(x => x.SessionsDTO, opt => opt.MapFrom(x => x.Sessions))
                .ForMember(x => x.CinemaRoomsDTO, opt => opt.MapFrom(x => x.CinemaRooms));
            CreateMap<Movie, MovieDTO>()
                .ForMember(x => x.MovieDescriptionDTO, opt => opt.MapFrom(x => x.MovieDescription));
            CreateMap<MovieDescription, MovieDescriptionDTO>();
            CreateMap<CinemaRoom, CinemaRoomDTO>();
            CreateMap<Session, SessionDTO>()
                .ForMember(x => x.MovieDTO, opt => opt.MapFrom(x => x.Movie));
        }
    }
}
