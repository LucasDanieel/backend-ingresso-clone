namespace Ingresso.Domain.Entities
{
    public class CinemaRoom
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public int CinemaId { get; private set; }
        public Cinema Cinema { get; private set; }

        public ICollection<Session> Sessions { get; private set; }
    }
}
