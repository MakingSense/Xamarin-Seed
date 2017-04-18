using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MvvmSeed.Domain.Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RandomizedStrings",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false).Annotation("Sqlite:Autoincrement", true),
                    LastTransformationTimestamp = table.Column<DateTimeOffset>(nullable: false),
                    LastTransformationValue = table.Column<string>(nullable: true),
                    RandomizationCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RandomizedStrings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "RandomizedStrings");
        }
    }
}
