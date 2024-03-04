using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class stationedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stations_Citizens_CitizenId",
                table: "Stations");

            migrationBuilder.DropIndex(
                name: "IX_Stations_CitizenId",
                table: "Stations");

            migrationBuilder.DropColumn(
                name: "CitizenId",
                table: "Stations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CitizenId",
                table: "Stations",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Stations_CitizenId",
                table: "Stations",
                column: "CitizenId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Stations_Citizens_CitizenId",
                table: "Stations",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
