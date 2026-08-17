using ClubLectura.Domain.Core;

namespace ClubLectura.Domain.Entities
{
    public class Asistencia : BaseEntity
    {
        public bool Asistio { get; set; }
        public int Valoracion { get; set; }

        public int MiembroId { get; set; }
        public Miembro? Miembro { get; set; }

        public int ReunionId { get; set; }
        public Reunion? Reunion { get; set; }
    }
}
