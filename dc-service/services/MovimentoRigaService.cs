using dc_repository.Entities;
using dc_repository.interfaces;
using dc_service.interfaces;
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

        public Task CreateRangeAsync(List<MovimentoRiga> entities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteRangeAsync(List<MovimentoRiga> entities)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovimentoRiga>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<MovimentoRiga> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<MovimentoRiga>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            throw new NotImplementedException();
        }

        public Task<MovimentoRiga> UpdateAsync(MovimentoRiga entity)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRangeAsync(List<MovimentoRiga> entities)
        {
            throw new NotImplementedException();
        }
    }
}
