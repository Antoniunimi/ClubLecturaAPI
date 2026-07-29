using AutoMapper;
using ClubLectura.Domain.Entities;
using ClubLectura.Infrastructure.Context;
using ClubLectura.Infrastructure.Core;
using ClubLectura.Infrastructure.Models;

namespace ClubLectura.Infrastructure.Repositories
{
    public class LibroRepository : BaseRepository<Libro>
    {
        private readonly IMapper _mapper;

        public LibroRepository(ClubLecturaContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<LibroModel>> GetLibros()
        {
            var libros = await GetAll();
            return _mapper.Map<List<LibroModel>>(libros);
        }

        public async Task<LibroModel?> GetLibro(int id)
        {
            var libro = await GetById(id);
            return libro is null ? null : _mapper.Map<LibroModel>(libro);
        }

        public async Task SaveLibro(LibroModel model)
        {
            var libro = _mapper.Map<Libro>(model);
            await Save(libro);
        }

        public async Task UpdateLibro(LibroModel model)
        {
            var libro = await GetById(model.Id);
            if (libro is null) return;

            _mapper.Map(model, libro);
            await Update(libro);
        }

        public async Task RemoveLibro(int id)
        {
            var libro = await GetById(id);
            if (libro is null) return;

            await Remove(libro);
        }
    }
}
