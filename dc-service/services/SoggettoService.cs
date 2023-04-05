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
    public class SoggettoService : ServiceBase<Soggetto>, ISoggettoService
    {
        public SoggettoService(IRepository<Soggetto> repository) : base(repository)
        {

        }

        public async Task<Soggetto> CreateAsync(Soggetto entity)
        {
            if (entity == null) throw new ArgumentNullException("Soggetto non presente");
            if (string.IsNullOrEmpty(entity.CodiceFiscale)) throw new ArgumentNullException("Il codice fiscale deve essere valorizzato");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var soggetto = await repository.CreateAsync(entity);
            return soggetto;
        }

        public async Task CreateRangeAsync(List<Soggetto> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("Il soggetto non puo essere vuoto");
            var listaSoggetti = new List<Soggetto>();
            foreach (var entity in entities)
            {
                if (entity.CodiceFiscale != null) listaSoggetti.Add(entity);
            }
            await repository.CreateRangeAsync(listaSoggetti);
        }

        public async Task DeleteAsync(int id)
        {
            var soggetto = await repository.Query().FirstOrDefaultAsync(soggetto => soggetto.IdSoggetto == id);
            if (soggetto != null)
            {
                await repository.DeleteAsync(soggetto);
            }
        }

        public async Task DeleteRangeAsync(List<Soggetto> entities)
        {
            var listaSoggettiEliminare = entities.Where(soggetto => soggetto.IdSoggetto > 0);
            await repository.DeleteRangeAsync(listaSoggettiEliminare);
        }

        public async Task<List<Soggetto>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<Soggetto> GetById(int id)
        {
            var soggetto = await repository.Query().FirstOrDefaultAsync(soggetto => soggetto.IdSoggetto == id);
            return soggetto ?? null;
        }

        public async Task<List<Soggetto>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var soggetti = await repository.Query().Where
                (soggetto => soggetto.RagioneSociale.Contains(filtro) || soggetto.CodiceFiscale.Contains(filtro))
                .OrderBy(soggetto => soggetto.RagioneSociale)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return soggetti;
        }

        public async Task<Soggetto> UpdateAsync(Soggetto entity)
        {
            if (entity == null) throw new ArgumentNullException("Soggetto non presente");
            if (string.IsNullOrEmpty(entity.CodiceFiscale)) throw new ArgumentNullException("Il codice fiscale deve essere valorizzato");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var soggetto = await repository.UpdateAsync(entity);
            return soggetto;
        }

        public async Task UpdateRangeAsync(List<Soggetto> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            var listaSoggetti = new List<Soggetto>();
            foreach (var entity in entities)
            {
                if (entity.CodiceFiscale != null) listaSoggetti.Add(entity);
            }
            await repository.UpdateRangeAsync(listaSoggetti);
        }
    }
}
