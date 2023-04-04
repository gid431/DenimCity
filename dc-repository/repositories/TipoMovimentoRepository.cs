using dc_repository.Context;
using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    public class TipoMovimentoRepository : Repository<TipoMovimento>
    {
        private readonly DcContext context;

        //costruttore
        public TipoMovimentoRepository(DcContext context) : base(context) => this.context = context;

        public override async Task<TipoMovimento> CreateAsync(TipoMovimento entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<TipoMovimento> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(TipoMovimento entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<TipoMovimento> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<TipoMovimento> Query() => context.TipoMovimenti.AsQueryable();

        public override async Task<TipoMovimento> UpdateAsync(TipoMovimento entity)
        {
            context.TipoMovimenti.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<TipoMovimento> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
