using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MDT.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class officer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfficerId",
                table: "Records",
                newName: "OfficerName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OfficerName",
                table: "Records",
                newName: "OfficerId");
        }
    }
}
