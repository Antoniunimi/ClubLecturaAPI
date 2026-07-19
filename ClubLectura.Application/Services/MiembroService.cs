using ClubLectura.Infrastructure.Models;
using ClubLectura.Infrastructure.Repositories;

namespace ClubLectura.Application.Services
{
    public class MiembroService
    {
        private readonly MiembroRepository _repository;

        public MiembroService(MiembroRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MiembroModel>> GetMiembros()
        {
            return await _repository.GetMiembros();
        }

        public async Task<MiembroModel?> GetMiembro(int id)
        {
            return await _repository.GetMiembro(id);
        }

        public async Task CrearMiembro(MiembroModel model)
        {
            await _repository.SaveMiembro(model);
        }

        public async Task ActualizarMiembro(MiembroModel model)
        {
            await _repository.UpdateMiembro(model);
        }

        public async Task EliminarMiembro(int id)
        {
            await _repository.RemoveMiembro(id);
        }
    }
}
