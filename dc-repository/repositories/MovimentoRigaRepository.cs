using dc_repository.Context;
using dc_repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dc_repository.repositories
{
    internal class MovimentoRigaRepository : Repository<MovimentoRiga>
    {
        private readonly DcContext context;

        //costruttore
        public MovimentoRigaRepository(DcContext context) : base(context) => this.context = context;

        public override async Task<MovimentoRiga> CreateAsync(MovimentoRiga entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task CreateRangeAsync(IEnumerable<MovimentoRiga> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteAsync(MovimentoRiga entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
        }

        public override async Task DeleteRangeAsync(IEnumerable<MovimentoRiga> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public override IQueryable<MovimentoRiga> Query() => context.MovimentoRighe.AsQueryable();

        public override async Task<MovimentoRiga> UpdateAsync(MovimentoRiga entity)
        {
            context.MovimentoRighe.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task UpdateRangeAsync(IEnumerable<MovimentoRiga> entities)
        {
            context.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
