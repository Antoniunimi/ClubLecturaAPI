using ClubLectura.Domain.Core;

namespace ClubLectura.Domain.Entities
{
    public class Miembro : Person
    {
        public DateTime FechaIngreso { get; set; }
    }
}
