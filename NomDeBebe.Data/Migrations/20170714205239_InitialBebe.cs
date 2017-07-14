using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace NomDeBebe.Data.Migrations
{
    public partial class InitialBebe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BabyNames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BabyNames", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "YearEntries",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BabyNameId = table.Column<int>(nullable: false),
                    NumberInYear = table.Column<int>(nullable: false),
                    RankInYear = table.Column<int>(nullable: false),
                    Year = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearEntries_BabyNames_BabyNameId",
                        column: x => x.BabyNameId,
                        principalTable: "BabyNames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_YearEntries_BabyNameId",
                table: "YearEntries",
                column: "BabyNameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "YearEntries");

            migrationBuilder.DropTable(
                name: "BabyNames");
        }
    }
}
