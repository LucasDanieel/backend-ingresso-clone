namespace Ingresso.Domain.Entities
{
    public class Movie
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string? Classification { get; private set; }
        public string Gender { get; private set; }
        public string? Duration { get; private set; }
        public DateOnly PremiereDate { get; private set; }
        public bool Trending { get; private set; }
        public bool PreSale { get; private set; }
        public string Slug { get; private set; }
        public string PublicIdPosterImage { get; private set; }
        public string PublicIdBannerImage { get; private set; }
        public string PosterImage { get; private set; }
        public string BannerImage { get; private set; }

        public MovieDescription MovieDescription { get; private set; }

        public Movie()
        { }
        
        public Movie(int id)
        {
            Id = id;
        }

        public Movie(int id, string name, string? classification, string gender, string? duration, DateOnly premiereDate,
            bool trending, bool preSale, string slug, string posterImage, string bannerImage, MovieDescription movieDescription, 
            string publicIdPosterImage, string publicIdBannerImage)
        {
            Id = id;
            Name = name;
            Classification = classification;
            Gender = gender;
            Duration = duration;
            PremiereDate = premiereDate;
            Trending = trending;
            PreSale = preSale;
            Slug = slug;
            PosterImage = posterImage;
            BannerImage = bannerImage;
            MovieDescription = movieDescription;
            PublicIdPosterImage = publicIdPosterImage;
            PublicIdBannerImage = publicIdBannerImage;
        }

    }
}
