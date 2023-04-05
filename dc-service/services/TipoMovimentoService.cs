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
    public class TipoMovimentoService : ServiceBase<TipoMovimento>, ITipoMovimentoService
    {
        public TipoMovimentoService(IRepository<TipoMovimento> repository) : base(repository)
        {

        }

        public async Task<TipoMovimento> CreateAsync(TipoMovimento entity)
        {
            if (entity == null) throw new ArgumentNullException("Tipo movimento non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var tipoMovimento = await repository.CreateAsync(entity);
            return tipoMovimento;
        }

        public async Task CreateRangeAsync(List<TipoMovimento> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("Tipo movimento non puo essere vuoto");
            var listaMovimenti = new List<TipoMovimento>();
            foreach (var entity in entities)
            {
                if (entity.Descrizione != null) listaMovimenti.Add(entity);
            }
            await repository.CreateRangeAsync(listaMovimenti);
        }

        public async Task DeleteAsync(int id)
        {
            var tipologiaMovimento = await repository.Query().FirstOrDefaultAsync(tipologia => tipologia.IdTipoMovimento == id);
            if (tipologiaMovimento != null)
            {
                await repository.DeleteAsync(tipologiaMovimento);
            }
        }

        public async Task DeleteRangeAsync(List<TipoMovimento> entities)
        {
            var listaTipoMovimentiEliminare = entities.Where(movimento => movimento.IdTipoMovimento > 0);
            await repository.DeleteRangeAsync(listaTipoMovimentiEliminare);
        }

        public async Task<List<TipoMovimento>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<TipoMovimento> GetById(int id)
        {
            var movimento = await repository.Query().FirstOrDefaultAsync(movimento => movimento.IdTipoMovimento == id);
            return movimento ?? null;
        }

        public async Task<List<TipoMovimento>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var movimenti = await repository.Query().Where
                (movimento => movimento.Descrizione.Contains(filtro))
                .OrderBy(movimento => movimento.Descrizione)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return movimenti;
        }

        public async Task<TipoMovimento> UpdateAsync(TipoMovimento entity)
        {
            if (entity == null) throw new ArgumentNullException("Movimento non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var movimento = await repository.UpdateAsync(entity);
            return movimento;
        }

        public async Task UpdateRangeAsync(List<TipoMovimento> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            var listaMovimenti = new List<TipoMovimento>();
            foreach (var entity in entities)
            {
                if (entity.Descrizione != null) listaMovimenti.Add(entity);
            }
            await repository.UpdateRangeAsync(listaMovimenti);
        }
    }
}
