using AutoMapper;
using ClubLectura.Domain.Entities;
using ClubLectura.Infrastructure.Context;
using ClubLectura.Infrastructure.Core;
using ClubLectura.Infrastructure.Models;

namespace ClubLectura.Infrastructure.Repositories
{
    public class ComentarioRepository : BaseRepository<Comentario>
    {
        private readonly IMapper _mapper;

        public ComentarioRepository(ClubLecturaContext context, IMapper mapper)
            : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<ComentarioModel>> GetComentarios()
        {
            var comentarios = await GetAll();
            return _mapper.Map<List<ComentarioModel>>(comentarios);
        }

        public async Task<ComentarioModel?> GetComentario(int id)
        {
            var comentario = await GetById(id);
            return comentario is null ? null : _mapper.Map<ComentarioModel>(comentario);
        }

        public async Task SaveComentario(ComentarioModel model)
        {
            var comentario = _mapper.Map<Comentario>(model);
            await Save(comentario);
        }

        public async Task UpdateComentario(ComentarioModel model)
        {
            var comentario = await GetById(model.Id);
            if (comentario is null) return;

            _mapper.Map(model, comentario);
            await Update(comentario);
        }

        public async Task RemoveComentario(int id)
        {
            var comentario = await GetById(id);
            if (comentario is null) return;

            await Remove(comentario);
        }
    }
}
