using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class fineofficer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OfficerName",
                table: "Fines",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OfficerName",
                table: "Fines");
        }
    }
}
