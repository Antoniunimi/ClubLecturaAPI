using AutoMapper;
using ClubLectura.Domain.Entities;
using ClubLectura.Infrastructure.Context;
using ClubLectura.Infrastructure.Core;
using ClubLectura.Infrastructure.Models;

namespace ClubLectura.Infrastructure.Repositories
{
    public class MiembroRepository : BaseRepository<Miembro>
    {
        private readonly IMapper _mapper;

        public MiembroRepository(ClubLecturaContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<MiembroModel>> GetMiembros()
        {
            var miembros = await GetAll();
            return _mapper.Map<List<MiembroModel>>(miembros);
        }

        public async Task<MiembroModel?> GetMiembro(int id)
        {
            var miembro = await GetById(id);
            return miembro is null ? null : _mapper.Map<MiembroModel>(miembro);
        }

        public async Task SaveMiembro(MiembroModel model)
        {
            var miembro = _mapper.Map<Miembro>(model);
            await Save(miembro);
        }

        public async Task UpdateMiembro(MiembroModel model)
        {
            var miembro = await GetById(model.Id);
            if (miembro is null) return;

            _mapper.Map(model, miembro);
            await Update(miembro);
        }

        public async Task RemoveMiembro(int id)
        {
            var miembro = await GetById(id);
            if (miembro is null) return;

            await Remove(miembro);
        }
    }
}
