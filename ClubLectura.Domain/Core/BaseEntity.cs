namespace ClubLectura.Domain.Core
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Borrado { get; set; }
    }
}
