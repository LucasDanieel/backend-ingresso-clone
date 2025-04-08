namespace Ingresso.Domain.Entities
{
    public class Session
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public List<string> Type { get; private set; }

        public int CinemaId { get; private set; }
        public Cinema Cinema { get; private set; }

        public int MovieId { get; private set; }
        public Movie Movie { get; private set; }

        public int CinemaRoomId { get; private set; }
        public CinemaRoom CinemaRoom { get; private set; }
    }
}
