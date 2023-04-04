using dc_repository.Entities;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace dc_repository.Context
{
    public class DcContext : DbContext
    {
        public DcContext() : base()
        {

        }

        public DcContext(DbContextOptions<DcContext> options) : base(options)
        {

        }

        public DbSet<Articolo> Articoli { get; set; }
        public DbSet<Categoria> Categorie { get; set; }
        public DbSet<Marchio> Marchi { get; set; }
        public DbSet<Movimento> Movimenti { get; set; }
        public DbSet<MovimentoRiga> MovimentoRighe { get; set; }
        public DbSet<Soggetto> Soggetti { get; set; }
        public DbSet<Tipologia> Tipologie { get; set; }
        public DbSet<TipoMovimento> TipoMovimenti { get; set; }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Articolo>().Property(p => p.PrezzoAcquisto).HasColumnType("decimal(18, 4)");
        }*/




    }
}
