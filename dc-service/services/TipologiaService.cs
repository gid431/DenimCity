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
    public class TipologiaService : ServiceBase<Tipologia>, ITipologiaService
    {
        public TipologiaService(IRepository<Tipologia> repository) : base(repository)
        {

        }

        public async Task<Tipologia> CreateAsync(Tipologia entity)
        {
            if (entity == null) throw new ArgumentNullException("Tipologia non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var tipologia = await repository.CreateAsync(entity);
            return tipologia;
        }

        public async Task CreateRangeAsync(List<Tipologia> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("Tipologia non puo essere vuoto");
            var listaTipologie = new List<Tipologia>();
            foreach (var entity in entities)
            {
                if (entity.Descrizione != null) listaTipologie.Add(entity);
            }
            await repository.CreateRangeAsync(listaTipologie);
        }

        public async Task DeleteAsync(int id)
        {
            var tipologia = await repository.Query().FirstOrDefaultAsync(tipologia => tipologia.IdTipologia == id);
            if (tipologia != null)
            {
                await repository.DeleteAsync(tipologia);
            }
        }

        public async Task DeleteRangeAsync(List<Tipologia> entities)
        {
            var listaTipologieEliminare = entities.Where(tipologia => tipologia.IdTipologia > 0);
            await repository.DeleteRangeAsync(listaTipologieEliminare);
        }

        public async Task<List<Tipologia>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<Tipologia> GetById(int id)
        {
            var tipologia = await repository.Query().FirstOrDefaultAsync(tipologia => tipologia.IdTipologia == id);
            return tipologia ?? null;
        }

        public async Task<List<Tipologia>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var tipologie = await repository.Query().Where
                (tipologia => tipologia.Descrizione.Contains(filtro))
                .OrderBy(tipologia => tipologia.Descrizione)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return tipologie;
        }

        public async Task<Tipologia> UpdateAsync(Tipologia entity)
        {
            if (entity == null) throw new ArgumentNullException("Tipologia non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione prodotto deve essere valorizzata");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var tipologia = await repository.UpdateAsync(entity);
            return tipologia;
        }

        public async Task UpdateRangeAsync(List<Tipologia> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            var listaTipologie = new List<Tipologia>();
            foreach (var entity in entities)
            {
                if (entity.Descrizione != null) listaTipologie.Add(entity);
            }
            await repository.UpdateRangeAsync(listaTipologie);
        }
    }
}
