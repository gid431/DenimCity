using dc_repository.Entities;
using dc_repository.interfaces;
using dc_repository.repositories;
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
    public class MovimentoService : ServiceBase<Movimento>, IMovimentoService
    {
        private readonly IRepository<Articolo> articoloRepository;
        private readonly IRepository<TipoMovimento> tipoMovimentoRepository;
        public MovimentoService(IRepository<Movimento> repository, IRepository<Articolo> articolo, IRepository<TipoMovimento> tipoMovimento) : base(repository)
        {
            this.articoloRepository = articolo;
            this.tipoMovimentoRepository = tipoMovimento;
        }

        //modifica update, delete

        private void UpdateGiacenza(Movimento entity)
        {
            var segno = 1;
            var tipoMovimento = tipoMovimentoRepository.Query().FirstOrDefault(x => x.IdTipoMovimento == entity.TipoMovimentoId);
            if(tipoMovimento != null) segno = (int)tipoMovimento.Segno;

            var listaArticoloId = entity.Righe.Select(x => x.ArticoloId).Distinct();
            var listArticoli = new List<Articolo>();
            foreach (var id in listaArticoloId)
            {
                var articolo = articoloRepository.Query().FirstOrDefault(x => x.IdArticolo == id);
                if(articolo != null)
                {
                    articolo.Giancenza = (segno * entity.Righe.Where(x => x.ArticoloId == articolo.IdArticolo).Sum(s => s.Quantita));
                    listArticoli.Add(articolo);
                }
            }
            articoloRepository.UpdateRangeAsync(listArticoli);
        }

        private void UpdateTotali(Movimento entity)
        {
            entity.Totale = entity.Righe.Sum(s => s.Quantita * s.Prezzo);
            entity.TotaleIva = entity.Righe.Sum(s => s.Quantita * s.Iva);
            entity.TotaleMovimento = entity.Righe.Sum(s => s.TotaleRiga);
        }

        public async Task<Movimento> CreateAsync(Movimento entity)
        {
            if (entity == null) throw new ArgumentNullException("Movimento non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzato");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";

            if (entity.Righe.Any())
            {
                UpdateTotali(entity);
                UpdateGiacenza(entity);
            }

            var movimento = await repository.CreateAsync(entity);
            return movimento;
        }

        public async Task CreateRangeAsync(List<Movimento> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("Il movimento non puo essere vuoto");
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var movimento = await repository.Query().FirstOrDefaultAsync(movimento => movimento.IdMovimento == id);

            if (movimento != null)
            {
                /*UpdateTotali(movimento);
                UpdateGiacenza(movimento);*/
                await repository.DeleteAsync(movimento);
            }

        }

        public async Task DeleteRangeAsync(List<Movimento> entities)
        {
            var listaMovimentiEliminare = entities.Where(movimento => movimento.IdMovimento > 0);
            await repository.DeleteRangeAsync(listaMovimentiEliminare);
        }

        public async Task<List<Movimento>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<Movimento> GetById(int id)
        {
            var movimento = await repository.Query().FirstOrDefaultAsync(movimento => movimento.IdMovimento == id);
            return movimento ?? null;
        }

        public async Task<List<Movimento>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var movimenti = await repository.Query().Where
                (movimento => movimento.Descrizione.Contains(filtro))
                .OrderBy(movimento => movimento.Descrizione)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return movimenti;
        }

        public async Task<Movimento> UpdateAsync(Movimento entity)
        {
            if (entity == null) throw new ArgumentNullException("Movimento non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var movimento = await repository.UpdateAsync(entity);
            return movimento;
        }

        public async Task UpdateRangeAsync(List<Movimento> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            await repository.UpdateRangeAsync(entities);
        }
    }
}
