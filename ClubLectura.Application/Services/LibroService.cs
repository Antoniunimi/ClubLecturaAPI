using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;

namespace ClubLectura.Application.Services
{
    public class LibroService
    {
        private readonly LibroRepository _repository;

        public LibroService(LibroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<LibroModel>> GetLibros()
        {
            return await _repository.GetLibros();
        }

        public async Task<LibroModel?> GetLibro(int id)
        {
            return await _repository.GetLibro(id);
        }

        public async Task CrearLibro(LibroModel model)
        {
            await _repository.SaveLibro(model);
        }

        public async Task ActualizarLibro(LibroModel model)
        {
            await _repository.UpdateLibro(model);
        }

        public async Task EliminarLibro(int id)
        {
            await _repository.RemoveLibro(id);
        }
    }
}
