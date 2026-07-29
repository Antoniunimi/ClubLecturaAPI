using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;

namespace ClubLectura.Application.Services
{
    public class ReunionService
    {
        private readonly ReunionRepository _repository;

        public ReunionService(ReunionRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ReunionModel>> GetReuniones()
        {
            return await _repository.GetReuniones();
        }

        public async Task<ReunionModel?> GetReunion(int id)
        {
            return await _repository.GetReunion(id);
        }

        public async Task CrearReunion(ReunionModel model)
        {
            await _repository.SaveReunion(model);
        }

        public async Task ActualizarReunion(ReunionModel model)
        {
            await _repository.UpdateReunion(model);
        }

        public async Task EliminarReunion(int id)
        {
            await _repository.RemoveReunion(id);
        }
    }
}
