using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class dbedit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Warrants_Citizens_CitizenId",
                table: "Warrants");

            migrationBuilder.DropIndex(
                name: "IX_Warrants_CitizenId",
                table: "Warrants");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Warrants_CitizenId",
                table: "Warrants",
                column: "CitizenId");

            migrationBuilder.AddForeignKey(
                name: "FK_Warrants_Citizens_CitizenId",
                table: "Warrants",
                column: "CitizenId",
                principalTable: "Citizens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
