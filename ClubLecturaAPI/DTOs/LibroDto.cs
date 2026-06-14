namespace ClubLecturaAPI.DTOs
{
    public class LibroDto
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int AnioPublicacion { get; set; }
        public string Genero { get; set; } = string.Empty;
    }
}
