using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PassaCall_Api.Migrations
{
    /// <inheritdoc />
    public partial class CriandoTabelaMatchHistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchHistory",
                columns: table => new
                {
                    IdMatchHistory = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Team = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Map = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WinTwoRounds = table.Column<int>(type: "int", nullable: false),
                    WinRoundPistolCt = table.Column<int>(type: "int", nullable: false),
                    WinRoundPistolTr = table.Column<int>(type: "int", nullable: false),
                    CtHalf = table.Column<int>(type: "int", nullable: false),
                    TrHalf = table.Column<int>(type: "int", nullable: false),
                    OverTime = table.Column<int>(type: "int", nullable: false),
                    MatchDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Event = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MapPick = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchHistory", x => x.IdMatchHistory);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchHistory");
        }
    }
}
