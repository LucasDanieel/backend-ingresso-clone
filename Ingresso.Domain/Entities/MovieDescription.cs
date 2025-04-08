namespace Ingresso.Domain.Entities
{
    public class MovieDescription
    {
        public int MovieId { get; private set; }
        public string Description { get; private set; }
        public string OriginalName { get; private set; }
        public string? Direction { get; private set; }
        public string? Distributor { get; private set; }
        public string? Country { get; private set; }

        public Movie? Movie { get; private set; }
    }
}
