namespace ClubLecturaAPI.DTOs
{
    public class MiembroDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Correo { get; set; } = string.Empty;
        public string Telefono { get; set; } = string.Empty;
        public DateTime FechaIngreso { get; set; }
    }
}
