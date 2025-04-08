using Ingresso.Application.DTOs.MovieDTOs;

namespace Ingresso.Application.DTOs.SessionDTOs
{
    public class SessionDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<string> Type { get; set; }

        public int CinemaId { get; set; }
        public int MovieId { get; set; }
        public MovieDTO? MovieDTO { get; set; }
        public int CinemaRoomId { get; set; }
    }
}
