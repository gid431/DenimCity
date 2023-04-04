using dc_repository.Context;
using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    public class TipologiaRepository : Repository<Tipologia>
    {
        private readonly DcContext context;

        //costruttore
        public TipologiaRepository(DcContext context) : base(context) => this.context = context;

        public override async Task<Tipologia> CreateAsync(Tipologia entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<Tipologia> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Tipologia entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<Tipologia> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<Tipologia> Query() => context.Tipologie.AsQueryable();

        public override async Task<Tipologia> UpdateAsync(Tipologia entity)
        {
            context.Tipologie.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<Tipologia> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
