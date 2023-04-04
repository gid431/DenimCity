using dc_repository.Context;
using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    public class MarchioRepository : Repository<Marchio>
    {
        private readonly DcContext context;

        //costruttore
        public MarchioRepository(DcContext context) : base(context) => this.context = context;

        public override async Task<Marchio> CreateAsync(Marchio entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<Marchio> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Marchio entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<Marchio> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<Marchio> Query() => context.Marchi.AsQueryable();

        public override async Task<Marchio> UpdateAsync(Marchio entity)
        {
            context.Marchi.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<Marchio> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
