namespace Ingresso.Domain.Entities
{
    public class Cinema
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Neighborhood { get; private set; }
        public string CityName { get; private set; }
        public string? Phone { get; private set; }
        public string Slug { get; private set; }
        public string PublicIdLogoImage { get; private set; }
        public string PublicIdBannerImage { get; private set; }
        public string LogoImage { get; private set; }
        public string BannerImage { get; private set; }
        public bool? SellProduct { get; private set; }
        public bool? MobileTicket { get; private set; }

        public int CityId { get; private set; }
        public City City { get; private set; }

        public ICollection<CinemaRoom> CinemaRooms { get; private set; }

        public ICollection<Session> Sessions { get; private set; }
    }
}
