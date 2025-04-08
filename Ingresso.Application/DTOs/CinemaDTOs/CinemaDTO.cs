using Ingresso.Application.DTOs.CinemaRoomDTOs;
using Ingresso.Application.DTOs.MovieDTOs;
using Ingresso.Application.DTOs.SessionDTOs;

namespace Ingresso.Application.DTOs.CinemaDTOs
{
    public class CinemaDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Neighborhood { get; set; }
        public string CityName { get; set; }
        public string? Phone { get; set; }
        public string Slug { get; set; }
        public string? LogoImage { get; set; }
        public string? BannerImage { get; set; }
        public bool? SellProduct { get; set; }
        public bool? MobileTicket { get; set; }

        public int CityId { get; set; }
        public ICollection<CinemaRoomDTO>? CinemaRoomsDTO { get; set; }
        public ICollection<SessionDTO>? SessionsDTO { get; set; }
        
    }
}
