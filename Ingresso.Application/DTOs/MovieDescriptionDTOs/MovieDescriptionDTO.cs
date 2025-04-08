using Ingresso.Domain.Entities;

namespace Ingresso.Application.DTOs.MovieDescriptionDTOs
{
    public class MovieDescriptionDTO
    {
        public int MovieId { get; set; }
        public string Description { get; set; }
        public string OriginalName { get; set; }
        public string? Direction { get; set; }
        public string? Distributor { get; set; }
        public string? Country { get; set; }
    }
}
