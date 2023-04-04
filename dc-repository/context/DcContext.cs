using dc_repository.Entities;
using Microsoft.EntityFrameworkCore;
#nullable disable

namespace dc_repository.Context
{
    /// <summary>
    /// classe che gestisce il contesto del db, ereditata da DbContext
    /// </summary>
    public class DcContext : DbContext
    {
        /// <summary>
        /// costruttore vuoto
        /// </summary>
        public DcContext() : base()
        {

        }
        /// <summary>
        /// costruttore con le options
        /// </summary>
        /// <param name="options"><see cref="DbContextOptions"/></param>
        public DcContext(DbContextOptions<DcContext> options) : base(options)
        {

        }

        public DbSet<Articolo> Articoli { get; set; }
        /// <summary>
        /// database tabella categorie
        /// </summary>
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
