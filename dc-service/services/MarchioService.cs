using dc_repository.Entities;
using dc_repository.interfaces;
using dc_service.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_service.services
{
#nullable disable
    public class MarchioService : ServiceBase<Marchio>, IMarchioService
    {
        public MarchioService(IRepository<Marchio> repository) : base(repository)
        {

        }

        public async Task<Marchio> CreateAsync(Marchio entity)
        {
            if (entity == null) throw new ArgumentNullException("Marchio non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("Il marchio deve essere valorizzato");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var marchio = await repository.CreateAsync(entity);
            return marchio;
        }

        public async Task CreateRangeAsync(List<Marchio> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("Il marchio non puo essere vuoto");
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var marchio = await repository.Query().FirstOrDefaultAsync(marchio => marchio.IdMarchi == id);
            if (marchio != null)
            {
                await repository.DeleteAsync(marchio);
            }
        }

        public async Task DeleteRangeAsync(List<Marchio> entities)
        {
            var listaMarchiEliminare = entities.Where(marchio => marchio.IdMarchi > 0);
            await repository.DeleteRangeAsync(listaMarchiEliminare);
        }

        public async Task<List<Marchio>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<Marchio> GetById(int id)
        {
            var marchio = await repository.Query().FirstOrDefaultAsync(marchio => marchio.IdMarchi == id);
            return marchio ?? null;
        }

        public async Task<List<Marchio>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var marchi = await repository.Query().Where
                (marchi => marchi.Descrizione.Contains(filtro))
                .OrderBy(marchio => marchio.Descrizione)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return marchi;
        }

        public async Task<Marchio> UpdateAsync(Marchio entity)
        {
            if (entity == null) throw new ArgumentNullException("Marchio non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var marchio = await repository.UpdateAsync(entity);
            return marchio;
        }

        public async Task UpdateRangeAsync(List<Marchio> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("Il marchio non puo essere vuoto");
            await repository.UpdateRangeAsync(entities);
        }
    }
}
