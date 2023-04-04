using dc_repository.Context;
using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    public class SoggettoRepository : Repository<Soggetto>
    {
        private readonly DcContext context;

        //costruttore
        public SoggettoRepository(DcContext context) : base(context) => this.context = context;

        public override async Task<Soggetto> CreateAsync(Soggetto entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<Soggetto> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Soggetto entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<Soggetto> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<Soggetto> Query() => context.Soggetti.AsQueryable();

        public override async Task<Soggetto> UpdateAsync(Soggetto entity)
        {
            context.Soggetti.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<Soggetto> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
