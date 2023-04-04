using dc_repository.Entities;
using dc_repository.interfaces;
using dc_service.interfaces;
using Microsoft.EntityFrameworkCore;

#nullable disable
namespace dc_service.services
{
    public class CategoriaService : ServiceBase<Categoria>, ICategoriaService
    {
        public CategoriaService(IRepository<Categoria> repository) : base(repository)
        {

        }

        public async Task<Categoria> CreateAsync(Categoria entity)
        {
            if (entity == null) throw new ArgumentNullException("Categoria non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataDiCreazione = DateTime.Now;
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Pippo";
            var categoria = await repository.CreateAsync(entity);
            return categoria;
        }

        public async Task CreateRangeAsync(List<Categoria> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La categoria non puo essere vuota");
            await repository.CreateRangeAsync(entities);
        }

        public async Task DeleteAsync(int id)
        {
            var categoria = await repository.Query().FirstOrDefaultAsync(categoria => categoria.IdCategoria == id);
            if (categoria != null)
            {
                await repository.DeleteAsync(categoria);
            }
        }

        public async Task DeleteRangeAsync(List<Categoria> entities)
        {
            var listaCategorieEliminare = entities.Where(categoria => categoria.IdCategoria > 0);
            await repository.DeleteRangeAsync(listaCategorieEliminare);
        }

        public async Task<List<Categoria>> GetAll()
        {
            return await repository.Query().ToListAsync();
        }

        public async Task<Categoria> GetById(int id)
        {
            var categoria = await repository.Query().FirstOrDefaultAsync(categoria => categoria.IdCategoria == id);
            return categoria ?? null;
        }

        public async Task<List<Categoria>> Pagination(int numeroPagine, string filtro, int recordPagine = 10)
        {
            numeroPagine = numeroPagine < 0 ? 0 : numeroPagine; //condizione ternaria
            var categorie = await repository.Query().Where
                (categorie => categorie.Descrizione.Contains(filtro))
                .OrderBy(articolo => articolo.Descrizione)
                .Skip(numeroPagine * recordPagine)
                .Take(recordPagine).ToListAsync();
            return categorie;

        }

        public async Task<Categoria> UpdateAsync(Categoria entity)
        {
            if (entity == null) throw new ArgumentNullException("Categoria non presente");
            if (string.IsNullOrEmpty(entity.Descrizione)) throw new ArgumentNullException("La descrizione deve essere valorizzata");
            entity.DataAggiornamento = DateTime.Now;
            entity.Operatore = "Paperino";
            var categoria = await repository.UpdateAsync(entity);
            return categoria;
        }

        public async Task UpdateRangeAsync(List<Categoria> entities)
        {
            if (!entities.Any()) throw new ArgumentNullException("La categoria non puo essere vuota");
            await repository.UpdateRangeAsync(entities);
        }

    }
}
