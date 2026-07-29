using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;

namespace ClubLectura.Application.Services
{
    public class ComentarioService
    {
        private readonly ComentarioRepository _repository;

        public ComentarioService(ComentarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ComentarioModel>> GetComentarios()
        {
            return await _repository.GetComentarios();
        }

        public async Task<ComentarioModel?> GetComentario(int id)
        {
            return await _repository.GetComentario(id);
        }

        public async Task CrearComentario(ComentarioModel model)
        {
            await _repository.SaveComentario(model);
        }

        public async Task ActualizarComentario(ComentarioModel model)
        {
            await _repository.UpdateComentario(model);
        }

        public async Task EliminarComentario(int id)
        {
            await _repository.RemoveComentario(id);
        }
    }
}
