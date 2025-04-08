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
    public class DtoToDomainMapping : Profile
    {
        public DtoToDomainMapping()
        {
            CreateMap<UserDTO, User>().ForMember(x => x.Password, opt => opt.Ignore());
            CreateMap<CityDTO, City>();
            CreateMap<CinemaDTO, Cinema>();
            CreateMap<MovieDTO, Movie>().ForMember(x => x.MovieDescription, opt =>
                opt.MapFrom(x => x.MovieDescriptionDTO));
            CreateMap<MovieDescriptionDTO, MovieDescription>();
            CreateMap<CinemaRoomDTO, CinemaRoom>();
            CreateMap<SessionDTO, Session>();
        }
    }
}
