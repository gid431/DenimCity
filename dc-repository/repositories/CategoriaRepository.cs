using dc_repository.Context;
using dc_repository.Entities;


#nullable disable

namespace dc_repository.repositories
{
    public class CategoriaRepository : Repository<Categoria>
    {
        private readonly DcContext context;
        public CategoriaRepository(DcContext context): base(context) => this.context = context;

        public override async Task<Categoria> CreateAsync(Categoria entity)
        {
            context.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Categoria> UpdateAsync(Categoria entity)
        {
            context.Update(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override async Task<Categoria> DeleteAsync(Categoria entity)
        {
            context.Remove(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public override IQueryable<Categoria> Query() => context.Categorie.AsQueryable();

        public override async Task DeleteRangeAsync(IEnumerable<Categoria> entities)
        {
            context.RemoveRange(entities);
            await context.SaveChangesAsync();
        }

               

        public async override Task CreateRangeAsync(IEnumerable<Categoria> entities)
        {
            await context.AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async override Task UpdateRangeAsync(IEnumerable<Categoria> entities)
        {
            context.Categorie.UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
