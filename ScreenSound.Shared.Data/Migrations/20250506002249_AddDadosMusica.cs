using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ScreenSound.Migrations
{
    /// <inheritdoc />
    public partial class AddDadosMusica : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData("Musicas", 
                new string[] {"Nome","AnoLancamento"},
                new object[,]
                {
                    {"Shinigame ou Hollow",2008 },
                    {"Ultimo Perdao", 2025 },
                    {"Tanjiro Kamado", 2017 },
                    {"Cupcake", 2023 },
                    {"Minha Jornada", 2022 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Musicas where id > 4");
        }
    }
}
