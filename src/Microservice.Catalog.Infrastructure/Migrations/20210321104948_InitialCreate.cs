using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microservice.Value.Infrastructure.Migrations
{
    /*
     * To add migration folder you need use the command:
     * Add-Migration InitialCreate -Project Microservice.Value.Infrastructure
     *
     * Please see - https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/projects?tabs=vs
     *
     * To update the database you need use the command:
     * Update-Database
     *
     * Please see - https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=vs
     */
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Values",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedUtc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastModifiedUtc = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Values", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Values");
        }
    }
}
