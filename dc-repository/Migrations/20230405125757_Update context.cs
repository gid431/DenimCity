using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace dc_repository.Migrations
{
    public partial class Updatecontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    IdCategoria = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.IdCategoria);
                });

            migrationBuilder.CreateTable(
                name: "Marchi",
                columns: table => new
                {
                    IdMarchi = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marchi", x => x.IdMarchi);
                });

            migrationBuilder.CreateTable(
                name: "Soggetti",
                columns: table => new
                {
                    IdSoggetto = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TipoSoggetto = table.Column<int>(type: "INTEGER", nullable: false),
                    RagioneSociale = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Indirizzo = table.Column<string>(type: "TEXT", nullable: true),
                    PartitaIva = table.Column<string>(type: "TEXT", maxLength: 11, nullable: true),
                    CodiceFiscale = table.Column<string>(type: "TEXT", maxLength: 16, nullable: true),
                    NumeroTelefono = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Cellulare = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Cap = table.Column<string>(type: "TEXT", maxLength: 5, nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Soggetti", x => x.IdSoggetto);
                });

            migrationBuilder.CreateTable(
                name: "Tipologie",
                columns: table => new
                {
                    IdTipologia = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipologie", x => x.IdTipologia);
                });

            migrationBuilder.CreateTable(
                name: "TipoMovimenti",
                columns: table => new
                {
                    IdTipoMovimento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Segno = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoMovimenti", x => x.IdTipoMovimento);
                });

            migrationBuilder.CreateTable(
                name: "Articoli",
                columns: table => new
                {
                    IdArticolo = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodiceProdotto = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 500, nullable: true),
                    PrezzoAcquisto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Giancenza = table.Column<decimal>(type: "TEXT", nullable: false),
                    PrezzoVendita = table.Column<decimal>(type: "TEXT", nullable: false),
                    UrlImmagine = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    CodiceABarre = table.Column<string>(type: "TEXT", maxLength: 13, nullable: true),
                    Sesso = table.Column<int>(type: "INTEGER", nullable: false),
                    TipologiaId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoriaId = table.Column<int>(type: "INTEGER", nullable: false),
                    MarchioId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articoli", x => x.IdArticolo);
                    table.ForeignKey(
                        name: "FK_Articoli_Categorie_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorie",
                        principalColumn: "IdCategoria",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articoli_Marchi_MarchioId",
                        column: x => x.MarchioId,
                        principalTable: "Marchi",
                        principalColumn: "IdMarchi",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articoli_Tipologie_TipologiaId",
                        column: x => x.TipologiaId,
                        principalTable: "Tipologie",
                        principalColumn: "IdTipologia",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movimenti",
                columns: table => new
                {
                    IdMovimento = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DataMovimento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SoggettoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TipoMovimentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    TotaleIva = table.Column<decimal>(type: "TEXT", nullable: false),
                    Totale = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotaleMovimento = table.Column<decimal>(type: "TEXT", nullable: false),
                    TipoPagamento = table.Column<int>(type: "INTEGER", nullable: false),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimenti", x => x.IdMovimento);
                    table.ForeignKey(
                        name: "FK_Movimenti_Soggetti_SoggettoId",
                        column: x => x.SoggettoId,
                        principalTable: "Soggetti",
                        principalColumn: "IdSoggetto",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movimenti_TipoMovimenti_TipoMovimentoId",
                        column: x => x.TipoMovimentoId,
                        principalTable: "TipoMovimenti",
                        principalColumn: "IdTipoMovimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovimentoRighe",
                columns: table => new
                {
                    IdMovimentoRiga = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MovimentoId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArticoloId = table.Column<int>(type: "INTEGER", nullable: false),
                    Prezzo = table.Column<decimal>(type: "TEXT", nullable: false),
                    Quantita = table.Column<decimal>(type: "TEXT", nullable: false),
                    Sconto = table.Column<decimal>(type: "TEXT", nullable: false),
                    Iva = table.Column<decimal>(type: "TEXT", nullable: false),
                    TotaleRiga = table.Column<decimal>(type: "TEXT", nullable: false),
                    DataDiCreazione = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAggiornamento = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Operatore = table.Column<string>(type: "TEXT", nullable: true),
                    Descrizione = table.Column<string>(type: "TEXT", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovimentoRighe", x => x.IdMovimentoRiga);
                    table.ForeignKey(
                        name: "FK_MovimentoRighe_Articoli_ArticoloId",
                        column: x => x.ArticoloId,
                        principalTable: "Articoli",
                        principalColumn: "IdArticolo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovimentoRighe_Movimenti_MovimentoId",
                        column: x => x.MovimentoId,
                        principalTable: "Movimenti",
                        principalColumn: "IdMovimento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_CategoriaId",
                table: "Articoli",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_MarchioId",
                table: "Articoli",
                column: "MarchioId");

            migrationBuilder.CreateIndex(
                name: "IX_Articoli_TipologiaId",
                table: "Articoli",
                column: "TipologiaId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimenti_SoggettoId",
                table: "Movimenti",
                column: "SoggettoId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimenti_TipoMovimentoId",
                table: "Movimenti",
                column: "TipoMovimentoId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoRighe_ArticoloId",
                table: "MovimentoRighe",
                column: "ArticoloId");

            migrationBuilder.CreateIndex(
                name: "IX_MovimentoRighe_MovimentoId",
                table: "MovimentoRighe",
                column: "MovimentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovimentoRighe");

            migrationBuilder.DropTable(
                name: "Articoli");

            migrationBuilder.DropTable(
                name: "Movimenti");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Marchi");

            migrationBuilder.DropTable(
                name: "Tipologie");

            migrationBuilder.DropTable(
                name: "Soggetti");

            migrationBuilder.DropTable(
                name: "TipoMovimenti");
        }
    }
}
