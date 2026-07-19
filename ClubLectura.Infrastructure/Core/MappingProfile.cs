using AutoMapper;
using ClubLectura.Domain.Entities;
using ClubLectura.Infrastructure.Models;

namespace ClubLectura.Infrastructure.Core
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Libro, LibroModel>().ReverseMap();
            CreateMap<Miembro, MiembroModel>().ReverseMap();
            CreateMap<Reunion, ReunionModel>().ReverseMap();
            CreateMap<Comentario, ComentarioModel>().ReverseMap();
        }
    }
}
