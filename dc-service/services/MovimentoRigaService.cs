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
    public class MovimentoRigaService : ServiceBase<MovimentoRiga>, IMovimentoRigaService
    {
        public MovimentoRigaService(IRepository<MovimentoRiga> repository) : base(repository)
        {

        }

        public async Task<MovimentoRiga> CreateAsync(MovimentoRiga entity)
        {
            if (entity == null) throw new ArgumentNullException("Movimento riga non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzato");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var movimentoRiga = await repository.CreateAsync(entity);
            return movimentoRiga;
        }

        public async Task CreateRangeAsync(List<MovimentoRiga> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La riga non puo essere vuota");
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var movimentoRiga = await repository.Query().FirstOrDefaultAsync(movimentoRiga => movimentoRiga.IdMovimentoRiga == id);
            if (movimentoRiga != null)
            {
                await repository.DeleteAsync(movimentoRiga);
            }
        }

        public async Task DeleteRangeAsync(List<MovimentoRiga> entities)
        {
            var listaMovimentiRigaEliminare = entities.Where(movimentoRiga => movimentoRiga.IdMovimentoRiga > 0);
            await repository.DeleteRangeAsync(listaMovimentiRigaEliminare);
        }

        public async Task<List<MovimentoRiga>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<MovimentoRiga> GetById(int id)
        {
            var movimentoRiga = await repository.Query().FirstOrDefaultAsync(movimentoRiga => movimentoRiga.IdMovimentoRiga == id);
            return movimentoRiga ?? null;
        }

        public async Task<List<MovimentoRiga>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var movimentiRiga = await repository.Query().Where
                (movimentoRiga => movimentoRiga.Descrizione.Contains(filtro))
                .OrderBy(movimentoRiga => movimentoRiga.Descrizione)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return movimentiRiga;
        }

        public async Task<MovimentoRiga> UpdateAsync(MovimentoRiga entity)
        {
            if (entity == null) throw new ArgumentNullException("Movimento riga non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var movimentoRiga = await repository.UpdateAsync(entity);
            return movimentoRiga;
        }

        public async Task UpdateRangeAsync(List<MovimentoRiga> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La lista non puo essere vuota");
            await repository.UpdateRangeAsync(entities);
        }
    }
}
