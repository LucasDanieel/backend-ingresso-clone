using Ingresso.Application.DTOs.MovieDescriptionDTOs;
using Ingresso.Domain.Entities;

namespace Ingresso.Application.DTOs.MovieDTOs
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Classification { get; set; }
        public string Gender { get; set; }
        public string? Duration { get; set; }
        public DateOnly PremiereDate { get; set; }
        public bool? Trending { get; set; }
        public bool? PreSale { get; set; }
        public string Slug { get; set; }
        public string? PublicIdPosterImage { get; set; }
        public string? PublicIdBannerImage { get; set; }
        public string? PosterImage { get; set; }
        public string? BannerImage { get; set; }

        public MovieDescriptionDTO MovieDescriptionDTO { get; set; }
    }
}
