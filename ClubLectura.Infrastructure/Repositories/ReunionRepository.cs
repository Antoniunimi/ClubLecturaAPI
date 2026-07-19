using AutoMapper;
using ClubLectura.Domain.Entities;
using ClubLectura.Infrastructure.Context;
using ClubLectura.Infrastructure.Core;
using ClubLectura.Infrastructure.Models;

namespace ClubLectura.Infrastructure.Repositories
{
    public class ReunionRepository : BaseRepository<Reunion>
    {
        private readonly IMapper _mapper;

        public ReunionRepository(ClubLecturaContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ReunionModel>> GetReuniones()
        {
            var reuniones = await GetAll();
            return _mapper.Map<List<ReunionModel>>(reuniones);
        }

        public async Task<ReunionModel?> GetReunion(int id)
        {
            var reunion = await GetById(id);
            return reunion is null ? null : _mapper.Map<ReunionModel>(reunion);
        }

        public async Task SaveReunion(ReunionModel model)
        {
            var reunion = _mapper.Map<Reunion>(model);
            await Save(reunion);
        }

        public async Task UpdateReunion(ReunionModel model)
        {
            var reunion = await GetById(model.Id);
            if (reunion is null) return;

            _mapper.Map(model, reunion);
            await Update(reunion);
        }

        public async Task RemoveReunion(int id)
        {
            var reunion = await GetById(id);
            if (reunion is null) return;

            await Remove(reunion);
        }
    }
}
