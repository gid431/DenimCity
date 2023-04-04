using dc_repository.Context;
using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    //creando i pattern che ti consente di rispettare create, read, update, delete di ogni entità del db in entities 
    public class ArticoloRepository : Repository<Articolo>
    {
        private readonly DcContext context;

        //costruttore
        public ArticoloRepository(DcContext context):base(context) => this.context = context;

        public override async Task<Articolo> CreateAsync(Articolo entity)
        {
            context.Articoli.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<Articolo> entities)
        {
            //quando usi async come metodo, await è obbligatorio, dice di aspettare 
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Articolo entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<Articolo> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<Articolo> Query() => context.Articoli.AsQueryable();

        public override async Task<Articolo> UpdateAsync(Articolo entity)
        {
            //di quella tabella fammi rappresentazione di un oggetto che può essere interrogato
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<Articolo> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
