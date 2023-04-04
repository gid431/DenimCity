using dc_repository.Context;
using dc_repository.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    public class MovimentoRepository : Repository<Movimento>
    {
        private readonly DcContext context;

        //costruttore
        public MovimentoRepository(DcContext context) : base(context) => this.context = context;

        public override async Task<Movimento> CreateAsync(Movimento entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<Movimento> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(Movimento entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<Movimento> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<Movimento> Query() => context.Movimenti.AsQueryable();

        public override async Task<Movimento> UpdateAsync(Movimento entity)
        {
            context.Movimenti.UpdateRange(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<Movimento> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
