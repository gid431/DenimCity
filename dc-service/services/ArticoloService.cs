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
    public class ArticoloService : ServiceBase<Articolo>, IArticoloService
    {
        public ArticoloService(IRepository<Articolo> repository) : base(repository)
        {

        }

        public async Task<Articolo> CreateAsync(Articolo entity)
        {
            if (entity == null) throw new ArgumentNullException("Articolo non presente");
            if (string.IsNullOrEmpty(entity.CodiceProdotto)) throw new ArgumentNullException("Il codice prodotto deve essere valorizzato");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var articolo = await repository.CreateAsync(entity);
            return articolo;
        }

        public async Task CreateRangeAsync(List<Articolo> entities)
        {
            //accertarci che ogni elemento della lista entità che mi stanno arrivando, siano popolate
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            var listaArticoli = new List<Articolo>();
            foreach(var entity in entities)
            {
                if (entity.CodiceProdotto != null) listaArticoli.Add(entity);
            }
            await repository.CreateRangeAsync(listaArticoli);

        }

        public async Task DeleteAsync(int id)
        {
            var articolo = await repository.Query().FirstOrDefaultAsync(articolo => articolo.IdArticolo == id);
            if(articolo != null)
            {
                await repository.DeleteAsync(articolo);
            }
        }

        public async Task DeleteRangeAsync(List<Articolo> entities)
        {
            var listaArticoliEliminare = entities.Where(articolo => articolo.IdArticolo > 0);
            await repository.DeleteRangeAsync(listaArticoliEliminare);
        }

        public async Task<Articolo> GetById(int id)
        {
            var articolo = await repository.Query().FirstOrDefaultAsync(articolo => articolo.IdArticolo == id);
            return articolo;
        }

        public List<Articolo> Pagination(int numeroPagine, int recordPagine)
        {
            throw new NotImplementedException();
        }

        public async Task<Articolo> UpdateAsync(Articolo entity)
        {
            if (entity == null) throw new ArgumentNullException("Articolo non presente");
            if (string.IsNullOrEmpty(entity.CodiceProdotto)) throw new ArgumentNullException("Il codice prodotto deve essere valorizzato");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var articolo = await repository.UpdateAsync(entity);
            return articolo;
            
        }

        public async Task UpdateRangeAsync(List<Articolo> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            var listaArticoli = new List<Articolo>();
            foreach (var entity in entities)
            {
                if (entity.CodiceProdotto != null) listaArticoli.Add(entity);
            }
            await repository.UpdateRangeAsync(listaArticoli);

        }
    }
}
