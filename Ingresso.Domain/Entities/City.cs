namespace Ingresso.Domain.Entities
{
    public class City
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string State { get; private set; }
        public string UF { get; private set; }
        public string Slug { get; private set; }

        public ICollection<Cinema> Cinemas { get; private set; }
    }
}
